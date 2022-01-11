using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float loadTime = 4.0f;
    float loseTime = 1.5f;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForSeconds(loadTime));
        }
        
    }

    private IEnumerator WaitForSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLoseScene()
    {
        StartCoroutine(WaitForSeconds(loseTime));
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadsOptionsScene()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

}
