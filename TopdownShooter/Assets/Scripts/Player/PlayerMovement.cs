using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerBase playerBase;
    [SerializeField] internal float moveSpeed;
    private bool isSubscribeMovementEvents;
    private Rigidbody2D rb;
    private float localScaleX;

    private void Awake()
    {
        playerBase = GetComponent<PlayerBase>();
        rb = GetComponent<Rigidbody2D>();
        isSubscribeMovementEvents = false;
        localScaleX = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (playerBase.state == PlayerState.Moving)
        {
            HandleMovement();
        }
    }

    private void OnEnable()
    {
        SubscribeMovementEvents();
    }

    private void OnDisable()
    {
        UnSubscribeMovementEvents();
    }

    private void SubscribeMovementEvents()
    {
        if (!isSubscribeMovementEvents)
        {
            isSubscribeMovementEvents = true;
            playerBase.playerInput.OnMovePressed += MovePlayer;
        }
    }

    private void UnSubscribeMovementEvents()
    {
        if (!isSubscribeMovementEvents)
        {
            isSubscribeMovementEvents = true;
            playerBase.playerInput.OnMovePressed += MovePlayer;
        }
    }

    private void MovePlayer(object sender, EventArgs e)
    {
       if (playerBase.state != PlayerState.Dashing)
        {
            playerBase.state = PlayerState.Moving;
        }
    }

    private void HandleMovement()
    {
        Vector3 moveDir = playerBase.playerInput.moveDir;
        rb.velocity = moveDir * moveSpeed;
        /*if (moveDir.x > 0)
        {
            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (moveDir.x < 0)
        {
            transform.localScale = new Vector3(-localScaleX, transform.localScale.y, transform.localScale.z);
        }*/
    }
}
