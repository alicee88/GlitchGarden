using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;

    int liveAttackers = 0;
    bool levelTimerFinished = false;
    float winTime = 4f;

    private void Start()
    {
        winLabel.SetActive(false);
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
    }

    private IEnumerator HandleWin()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winTime);
        FindObjectOfType<LevelLoader>().LoadNextScene();

    }
}
