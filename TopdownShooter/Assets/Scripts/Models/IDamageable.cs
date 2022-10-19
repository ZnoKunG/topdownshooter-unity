using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public abstract class IDamageable : MonoBehaviour
{
    private HealthSystem healthSystem;
    [SerializeField]
    private int health;
    [SerializeField]
    private Transform deadParticles;
    

    protected virtual void Awake()
    {
        healthSystem = new HealthSystem(health);
        healthSystem.OnDead += Damageable_Dead;
    }

    private void Damageable_Dead(object sender, EventArgs e)
    {
        Destroy(gameObject);
        if (deadParticles != null) {
            Transform deadParticleTransform = Instantiate(deadParticles);
            Destroy(deadParticleTransform, 5f);
        }
    }

    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }

    
}
