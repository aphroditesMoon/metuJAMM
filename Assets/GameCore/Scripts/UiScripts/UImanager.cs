using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public PlayerData playerData;
    
    public Image playerHealthBar;

    private void Update()
    {
        //playerHealthBar.transform.position = PlayerLoc.instance.transform.position;
        
        //playerHealthBar.fillAmount = playerData.baseHealth;
    }
}
