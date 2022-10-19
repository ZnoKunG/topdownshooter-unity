using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private AnimationCurve dashSpeedAnimationCurve;
    private PlayerBase playerBase;

    private float dashTime;
    private Vector3 dashDir;
    private float dashSpeed;
    private Rigidbody2D rb;
    private bool isDashable;
    [SerializeField] private float dashCooldown;

    private bool isSubscribeDashEvents;

    private void Awake()
    {
        playerBase = GetComponent<PlayerBase>();
        rb = GetComponent<Rigidbody2D>();
        isDashable = true;
    }

    private void FixedUpdate()
    {
        if (playerBase.state == PlayerState.Dashing)
        {
            HandleDash();
        }  
    }

    private void OnEnable()
    {
        if (!isSubscribeDashEvents)
        {
            isSubscribeDashEvents = false;
            playerBase.playerInput.OnDashPressed += DashPlayer;
        }
    }

    private void OnDisable()
    {

        if (isSubscribeDashEvents)
        {
            isSubscribeDashEvents = true;
            playerBase.playerInput.OnDashPressed -= DashPlayer;
        }
    }

    private void DashPlayer(object sender, EventArgs eventArgs)
    {
        if (isDashable)
        {
            playerBase.state = PlayerState.Dashing;
            SetDashProperty();
        }
    }

    private void SetDashProperty()
    {
        dashTime = 0;
        dashDir = playerBase.playerInput.moveDir;
        dashSpeed = dashSpeedAnimationCurve.Evaluate(dashTime);
        StartCoroutine(DashCountCoroutine());
    }

    private void HandleDash()
    {
        dashTime += Time.deltaTime;
        dashSpeed = dashSpeedAnimationCurve.Evaluate(dashTime);
        rb.velocity = dashDir * dashSpeed;
        if (dashSpeed <= playerBase.playerMovement.moveSpeed)
        {
            playerBase.state = PlayerState.Standing;
        }
    }
    
    private IEnumerator DashCountCoroutine()
    {
        isDashable = false;
        yield return new WaitForSeconds(dashCooldown);
        isDashable = true;
    }
}
