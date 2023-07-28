using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikazeBehaviour : MonoBehaviour
{
    public EnemyKamikazeData EnemyKamikazeData;

    private CapsuleCollider2D _capsuleCollider2D;

    private Vector3 playerPos;
    private float distance;

    private void Awake()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        EnemyKamikazeData.baseHealth = EnemyKamikazeData.baseHealth;
    }

    private void Update()
    {
        playerPos = PlayerLoc.instance.transform.position;
        distance = Vector2.Distance(transform.position, playerPos);

        FollowPlayer();
        SyrianBomb();
    }
    
    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, EnemyKamikazeData.baseSpeed * Time.deltaTime); 
    }

    private void SyrianBomb()
    {
        if (distance < 3f)
        {
            Debug.Log("xxx");
        }
    }
}
