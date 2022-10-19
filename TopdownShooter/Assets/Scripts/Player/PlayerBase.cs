using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : IDamageable
{
    internal PlayerInput playerInput;
    internal PlayerMovement playerMovement;
    internal PlayerCollision playerCollision;
    internal PlayerShoot playerShoot;
    internal PlayerState state;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("PlayerBase Script Awaking");
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollision = GetComponent<PlayerCollision>();
        playerShoot = GetComponent<PlayerShoot>();
        state = PlayerState.Standing;
    }


}

public enum PlayerState
{
    Standing,
    Moving,
    Dashing,
    Shooting,
}
