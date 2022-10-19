using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int projectileDamage;
    [SerializeField]
    private Transform explodeParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null) {
            target.Damage(projectileDamage);
            Destroy(gameObject);
            if (explodeParticles != null)
            {
                Transform explodeParticlesTransform = Instantiate(explodeParticles);
                Destroy(explodeParticlesTransform, 5f);
            }
        }
    }
}
