using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyOneMonobehavior : MonoBehaviour
{
    public EnemyOneData EnemyOneData;

    private CapsuleCollider2D _capsuleCollider2D;

    private void Awake()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _capsuleCollider2D.size = new Vector2(EnemyOneData.closeRadiusX, EnemyOneData.closeRadiusY);

        EnemyOneData.baseHealth = EnemyOneData.baseHealth;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 playerPos = PlayerLoc.instance.transform.position;
        
        float distance = Vector2.Distance(transform.position, playerPos);

        if (distance < EnemyOneData.closeDistance)
        {
            transform.position = transform.position;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, EnemyOneData.baseSpeed * Time.deltaTime); 
        }
    }
}
