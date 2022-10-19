using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletRaycast
{
    public static void Shoot(Vector3 fromPosition, Vector3 toPosition, int shootDamage)
    {
        Vector3 shootDirection = toPosition - fromPosition;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(toPosition, shootDirection);
        IDamageable damageable = raycastHit2D.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(shootDamage);
        }
    }
}
