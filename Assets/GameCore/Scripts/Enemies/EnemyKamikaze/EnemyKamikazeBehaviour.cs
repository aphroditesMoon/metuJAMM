using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKamikazeBehaviour : MonoBehaviour
{
    public EnemyKamikazeData EnemyKamikazeData;

    public Slider healthBar;
    public float KamikazeHealth;

    public ParticleSystem ParticleSystem;

    private Animator _animator;

    private Vector3 playerPos;
    
    private float distance;
    
    private bool isBombed = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        KamikazeHealth = EnemyKamikazeData.baseHealth;
    }

    private void Update()
    {
        healthBar.value = KamikazeHealth;
        
        playerPos = PlayerLoc.instance.transform.position;
        distance = Vector2.Distance(transform.position, playerPos);

        if (KamikazeHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        FollowPlayer();
        SyrianBomb();
    }
    
    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos, EnemyKamikazeData.baseSpeed * Time.deltaTime); 
    }
    
    private void SyrianBomb()
    {
        if (distance < 1f && !isBombed)
        {
            CameraShakeScript.instance.StartShake(200);
            _animator.SetTrigger("Boom");
            PlayerLoc.instance.PlayerHealth -= 2.5f;
            isBombed = true;
            ParticleSystem.transform.position = transform.position;
            ParticleSystem.Play();
            Destroy(gameObject, .4f);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PlayerPolygon" && PlayerLoc.instance._controller.PlayerKeyboard.AttackE.triggered)
        {
            CameraShakeScript.instance.StartShake(200);
            PlayerLoc.instance.AttackMace();
            KamikazeHealth -= 25f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.tag == "PlayerSword")
        {
            CameraShakeScript.instance.StartShake(200);
            KamikazeHealth -= 20f;
        }
        
        if (other.transform.gameObject.tag == "PlayerDagger")
        {
            CameraShakeScript.instance.StartShake(200);
            KamikazeHealth -= 15f;
        }
    }
}
