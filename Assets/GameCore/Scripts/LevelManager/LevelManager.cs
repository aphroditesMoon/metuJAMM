using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        var activeScene = SceneManager.GetActiveScene();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (activeScene == SceneManager.GetSceneByName("MainMenu"))
        {
            
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
    }
}
