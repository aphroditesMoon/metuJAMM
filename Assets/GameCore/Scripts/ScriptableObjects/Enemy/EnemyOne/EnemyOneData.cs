using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyOneData : ScriptableObject
{
    public float baseSpeed;
    [Range(0f,100f)]
    public float baseHealth;
    public float closeRadiusX;
    public float closeRadiusY;
    public float closeDistance;
}
