using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLoc : MonoBehaviour
{
    public static PlayerLoc instance { get; private set; }

    private Controller _controller;
    private Vector2 _moveVector = Vector2.zero;
    private Rigidbody2D _rigidbody2D;

    public PlayerData playerData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        _controller = new Controller();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        playerData.baseHealth = playerData.baseHealth;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _moveVector * playerData.baseSpeed;
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
}