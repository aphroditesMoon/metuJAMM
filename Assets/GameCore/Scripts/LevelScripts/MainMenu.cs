using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        LevelManager.instance.LoadScene(sceneName);
    }
}
