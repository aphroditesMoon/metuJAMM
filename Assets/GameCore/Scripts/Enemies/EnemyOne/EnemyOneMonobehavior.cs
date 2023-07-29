using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyOneMonobehavior : MonoBehaviour
{
    public EnemyOneData EnemyOneData;

    private CapsuleCollider2D _capsuleCollider2D;
    
    private Vector3 playerPos;
    private float distance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Awake()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _capsuleCollider2D.size = new Vector2(EnemyOneData.closeRadiusX, EnemyOneData.closeRadiusY);

        EnemyOneData.baseHealth = EnemyOneData.baseHealth;
    }

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        playerPos = PlayerLoc.instance.transform.position;
        distance = Vector2.Distance(transform.position, playerPos);
        
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (distance < EnemyOneData.closeDistance)
        {
            transform.position = transform.position;
            Projectile();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, EnemyOneData.baseSpeed * Time.deltaTime); 
        }
    }
    
    private void Projectile()
    {
        if (timeBtwShots <= 0)
        {
            var a = Instantiate(EnemyOneData.projectile, transform.position, quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
