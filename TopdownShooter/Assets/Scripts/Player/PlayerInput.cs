using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerInput : MonoBehaviour
{
    internal Vector3 moveDir;
    private PlayerBase playerBase;

    private const float DIAGONAL_VELOCITY_FALLOFF = 0.7f;
    public event EventHandler OnMovePressed;
    public event EventHandler OnDashPressed;
    public event EventHandler OnShootMissilePressed;
    public event EventHandler OnShootRaycastPressed;
    private void Awake()
    {
        Debug.Log("PlayerInput Script Awaking");
        playerBase = GetComponent<PlayerBase>();
        
    }

    private void Update()
    {
        moveDir = Vector3.zero;
        // One Axis Movement Input
        HandleMovementInput();

        // Two Axis Movement Input
        HandleDiagonalMovementInput();

        // Dash Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDashPressed?.Invoke(this, EventArgs.Empty);
        }

        // Shoot Input
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnShootMissilePressed?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnShootRaycastPressed?.Invoke(this, EventArgs.Empty);
        }
    }

    private void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1f;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1f;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1f;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1f;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
    }

    private void HandleDiagonalMovementInput()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            moveDir.x = -DIAGONAL_VELOCITY_FALLOFF;
            moveDir.y = DIAGONAL_VELOCITY_FALLOFF;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            moveDir.x = -DIAGONAL_VELOCITY_FALLOFF;
            moveDir.y = -DIAGONAL_VELOCITY_FALLOFF;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            moveDir.x = DIAGONAL_VELOCITY_FALLOFF;
            moveDir.y = DIAGONAL_VELOCITY_FALLOFF;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            moveDir.x = DIAGONAL_VELOCITY_FALLOFF;
            moveDir.y = -DIAGONAL_VELOCITY_FALLOFF;
            OnMovePressed?.Invoke(this, EventArgs.Empty);
        }
    }

}
