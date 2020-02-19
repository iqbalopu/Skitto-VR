using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeController : MonoBehaviour {

    public static LevelChangeController instance;
    public int LoadedLevelIndex;
    private void Awake()
    {
        QualitySettings.antiAliasing = 8;
        instance = this;
    }
    private void Start()
    {
        LoadedLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        //Reload Current Level
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadNextLevel(LoadedLevelIndex);
        }
        //Load Previous Level
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (LoadedLevelIndex > 0)
            {
                LoadedLevelIndex --;
                LoadNextLevel(LoadedLevelIndex);
            }
            else LoadNextLevel(LoadedLevelIndex);
        }
        //Load Next Level
        if(Input.GetKeyDown(KeyCode.N))
        {
            if (LoadedLevelIndex < 4)
            {
                LoadedLevelIndex++;
                LoadNextLevel(LoadedLevelIndex);
            }
            else LoadNextLevel(0);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void LoadNextLevel(int LevelToLoad)
    {
        LoadedLevelIndex = LevelToLoad;
        StartCoroutine(LoadLevel(LevelToLoad));
    }
    IEnumerator LoadLevel(int LevelToLoad)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(LevelToLoad);
        yield return async;
        Debug.Log("Loading complete");
    }
}
