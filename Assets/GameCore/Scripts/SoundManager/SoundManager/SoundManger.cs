using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManger : MonoBehaviour
{
    public AudioSource[] audios;

    private void Update()
    {
        SoundManagerFNC();
    }

    public void SoundManagerFNC()
    {
        var activeScene = SceneManager.GetActiveScene();
        
        if (activeScene.name == "LevelOne")
        {
            audios[0].Play();
        }
        
        if (activeScene.name == "LevelTwo")
        {
            audios[1].Play();
        }
        
        if (activeScene.name == "LevelThree")
        {
            audios[2].Play();
        }
        
        if (activeScene.name == "LevelFour")
        {
            audios[3].Play();
        }
        
        if (activeScene.name == "LevelFive")
        {
            audios[4].Play();
        }
        
        if (activeScene.name == "LevelSix")
        {
            audios[5].Play();
        }
    }
}
