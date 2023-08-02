using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManger : MonoBehaviour
{
    public AudioSource[] audios;
    public AudioClip[] AudioClips;

    private void Update()
    {
        
        
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        SoundManagerFNC();
    }

    public void SoundManagerFNC()
    {
        Scene activeScene = SceneManager.GetActiveScene();

        Debug.Log("Active Scene Name: " + activeScene.name);

        if (activeScene.name == "LevelOne")
        {
            Debug.Log("Playing audio clip 1");
            audios[0].Play();
        }
        else if (activeScene.name == "LevelTwo")
        {
            Debug.Log("Playing audio clip 2");
            audios[1].Play();
        }
        else if (activeScene.name == "LevelThree")
        {
            Debug.Log("Playing audio clip 3");
            audios[2].Play();
        }
        else if (activeScene.name == "LevelFour")
        {
            Debug.Log("Playing audio clip 4");
            audios[3].Play();
        }
        else if (activeScene.name == "LevelFive")
        {
            Debug.Log("Playing audio clip 5");
            audios[4].Play();
        }
        else if (activeScene.name == "LevelSix")
        {
            Debug.Log("Playing audio clip 6");
            audios[5].Play();
        }
        else
        {
            Debug.LogWarning("No audio clip found for this scene: " + activeScene.name);
        }
    }
}
