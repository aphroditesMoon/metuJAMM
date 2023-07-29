using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneProjectile : MonoBehaviour
{
    public float projectileSpeed;
    
    private Vector2 _target;
    
    private void Start()
    {
        _target = new Vector2(PlayerLoc.instance.transform.position.x , PlayerLoc.instance.transform.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, projectileSpeed * Time.deltaTime);

        if (transform.position.x == _target.x && transform.position.y == _target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.GetInstanceID() == PlayerLoc.instance.transform.gameObject.GetInstanceID())
        {
            Destroy(gameObject);
        }
    }
}