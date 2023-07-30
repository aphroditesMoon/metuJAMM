using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyCandyData : ScriptableObject
{
    public float baseSpeed;
    [Range(0f, 100f)] 
    public float baseHealth;
}
