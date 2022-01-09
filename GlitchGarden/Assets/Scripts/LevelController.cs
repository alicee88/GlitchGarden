using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel; 

    int liveAttackers = 0;
    bool levelTimerFinished = false;
    float winTime = 4f;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        Time.timeScale = 1;
    }

    public void AddAttacker()
    {
        liveAttackers++;
    }

    public void RemoveAttacker()
    {
        liveAttackers--;

        if (levelTimerFinished && liveAttackers <= 0)
        {
            StartCoroutine(HandleWin());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i].StopSpawning();
        }
        HandleLose();
    }

    private IEnumerator HandleWin()
    {
        winLabel.SetActive(true);
        Time.timeScale = 0;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();

    }

    public void HandleLose()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
