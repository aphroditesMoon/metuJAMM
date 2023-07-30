using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public PlayerData playerData;
    
    public Slider playerHealthBar;

    private void Update()
    {
        playerHealthBar.value = PlayerLoc.instance.PlayerHealth;
    }
}
