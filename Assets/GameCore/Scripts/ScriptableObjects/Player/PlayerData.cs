using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public float baseSpeed;
    [Range(0f,250f)]
    public float baseHealth;
}
