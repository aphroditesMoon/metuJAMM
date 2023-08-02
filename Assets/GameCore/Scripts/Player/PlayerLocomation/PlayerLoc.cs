using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Schema;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerLoc : MonoBehaviour
{
    public static PlayerLoc instance { get; private set; }

    [NonSerialized]
    public Controller _controller;
    private Vector2 _moveVector = Vector2.zero;
    private Rigidbody2D _rigidbody2D;

    public PlayerData playerData;

    [NonSerialized]
    public float PlayerHealth;

    [SerializeField] 
    private Animator playerAnimator;

    //sword
    private float _swordTimer;
    [SerializeField]
    private float swordSpeed;
    
    //dagger
    private float _daggerTimer;
    [SerializeField] 
    private float daggerSpeed;
    
    //mace
    [SerializeField]
    private GameObject mace;

    [NonSerialized]
    public Vector3 mouseDirection;
    
    public AudioSource[] sfxS;

    private void GetMouseDirection()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, 0));

        mouseDirection = mouseWorldPosition - transform.position;

        mouseDirection.Normalize();
    }

    private void Awake()
    {
        Time.timeScale = 1f;
        
        if (instance == null)
        {
            instance = this;
        }
        
        _controller = new Controller();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        PlayerHealth = playerData.baseHealth;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _moveVector * playerData.baseSpeed;
    }

    private void Update()
    {
        if (PlayerHealth <= 0)
        {
            sfxS[2].Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        AttackSword();
        AttackDagger();
        
        GetMouseDirection();
    }

    private void OnEnable()
    {
        _controller.Enable();
        _controller.PlayerKeyboard.Movement.performed += OnMovementPerformed;
        _controller.PlayerKeyboard.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        _controller.Disable();
        _controller.PlayerKeyboard.Movement.performed -= OnMovementPerformed;
        _controller.PlayerKeyboard.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveVector = value.ReadValue<Vector2>();
    }
    
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        _moveVector = Vector2.zero;
    }
    
    private void AttackSword()
    {
        if (_swordTimer <= 0f)
        {
            if (_controller.PlayerKeyboard.Attack.triggered)
            {
                if (mouseDirection.x >= 0 && mouseDirection.y >= 0)
                {
                    playerAnimator.SetTrigger("TopLeftAttack");
                    _swordTimer = swordSpeed;
                }
                else if (mouseDirection.x >= 0 && mouseDirection.y < 0)
                {
                    playerAnimator.SetTrigger("TopLeftAttack");
                    _swordTimer = swordSpeed;
                }
                else if (mouseDirection.x < 0 && mouseDirection.y >= 0)
                {
                    playerAnimator.SetTrigger("TopRightAttack");
                    _swordTimer = swordSpeed;
                }
                else
                {
                    playerAnimator.SetTrigger("TopRightAttack");
                    _swordTimer = swordSpeed;
                }
            }
        } 
        else
        {
            _swordTimer -= Time.deltaTime;
        }
    }

    private void AttackDagger()
    {
        if (_daggerTimer <= 0f)
        {
            if (_controller.PlayerKeyboard.AttackQ.triggered)
            {
                if (mouseDirection.x >= 0 && mouseDirection.y >= 0)
                {
                    playerAnimator.SetTrigger("DaggerTopRight");
                    _daggerTimer = daggerSpeed;
                }
                else if (mouseDirection.x >= 0 && mouseDirection.y < 0)
                {
                    playerAnimator.SetTrigger("DaggerBottomRight");
                    _daggerTimer = daggerSpeed;
                }
                else if (mouseDirection.x < 0 && mouseDirection.y >= 0)
                {
                    playerAnimator.SetTrigger("DaggerTopLeft");
                    _daggerTimer = daggerSpeed;
                }
                else
                {
                    playerAnimator.SetTrigger("DaggerBottomLeft");
                    _daggerTimer = daggerSpeed;
                }
            }
        } 
        else
        {
            _daggerTimer -= Time.deltaTime;
        }
    }

    public async void AttackMace()
    {
        mace.SetActive(true);
        await Task.Delay(500);
        mace.SetActive(false);
    }
}