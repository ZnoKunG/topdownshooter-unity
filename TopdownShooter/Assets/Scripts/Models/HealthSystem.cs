using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem
{
    private int health;
    private int healthMax;

    public event EventHandler OnDead;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    public HealthSystem(int health)
    {
        this.health = health;
        this.healthMax = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        OnDamaged?.Invoke(this, EventArgs.Empty);
        if (health <= 0)
        {
            health = 0;
            OnDead?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        OnHealed?.Invoke(this, EventArgs.Empty);
        if (health >= healthMax)
        {
            health = healthMax;
        }
    }
}
