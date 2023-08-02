using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOneMonobehavior : MonoBehaviour
{
    public static EnemyOneMonobehavior instance { get; private set; }

    public Slider healthBar;
    public float OneHealth;
    
    public EnemyOneData EnemyOneData;

    private CapsuleCollider2D _capsuleCollider2D;
    
    public ParticleSystem ParticleSystem;
    
    private Vector3 playerPos;
    private float distance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _capsuleCollider2D.size = new Vector2(EnemyOneData.closeRadiusX, EnemyOneData.closeRadiusY);

        OneHealth = EnemyOneData.baseHealth;
    }

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        healthBar.value = OneHealth;
        
        playerPos = PlayerLoc.instance.transform.position;
        distance = Vector2.Distance(transform.position, playerPos);
        
        if (OneHealth <= 0)
        {
            PlayerLoc.instance.sfxS[1].Play();
            gameObject.SetActive(false);
        }
        
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
            PlayerLoc.instance.sfxS[0].Play();
            var a = Instantiate(EnemyOneData.projectile, transform.position, quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PlayerPolygon" && PlayerLoc.instance._controller.PlayerKeyboard.AttackE.triggered)
        {
            CameraShakeScript.instance.StartShake(200);
            PlayerLoc.instance.AttackMace();
            OneHealth -= 25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PlayerSword")
        {
            CameraShakeScript.instance.StartShake(200);
            OneHealth -= 20f;
        }
        
        if (other.transform.gameObject.tag == "PlayerDagger")
        {
            CameraShakeScript.instance.StartShake(200);
            OneHealth -= 15f;
        }
    }
}
