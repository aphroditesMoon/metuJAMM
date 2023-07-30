using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieGuyBehavior : MonoBehaviour
{
    public static CookieGuyBehavior instance { get; private set; }

    public Slider healthBar;
    public float CookieHealth;

    public EnemyCandyData EnemyCandyData;

    private Animator _animator;
    
    private Vector3 playerPos;
    private float distance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _animator = GetComponent<Animator>();
        
        CookieHealth = EnemyCandyData.baseHealth;
    }

    private void Update()
    {
        healthBar.value = CookieHealth;
        
        playerPos = PlayerLoc.instance.transform.position;
        distance = Vector2.Distance(transform.position, playerPos);

        if (CookieHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, EnemyCandyData.baseSpeed * Time.deltaTime);

        if (distance < 2f)
        {
            _animator.SetTrigger("Attack");
        }
        else
        {
            _animator.SetTrigger("NonAttack");
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PlayerPolygon" && PlayerLoc.instance._controller.PlayerKeyboard.AttackE.triggered)
        {
            CameraShakeScript.instance.StartShake(200);
            PlayerLoc.instance.AttackMace();
            CookieHealth -= 25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PlayerSword")
        {
            CameraShakeScript.instance.StartShake(200);
            CookieHealth -= 20f;
        }
        
        if (other.transform.gameObject.tag == "PlayerDagger")
        {
            CameraShakeScript.instance.StartShake(200);
            CookieHealth -= 15f;
        }
        
        if (other.transform.gameObject.GetInstanceID() == PlayerLoc.instance.transform.gameObject.GetInstanceID())
        {
            CameraShakeScript.instance.StartShake(200);
            PlayerLoc.instance.PlayerHealth -= 1.5f;
        }
    }
}
