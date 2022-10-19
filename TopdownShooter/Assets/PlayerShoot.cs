using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZnoKunG.Utils;

public class PlayerShoot : MonoBehaviour
{
    private Vector2 moveDirection;
    private PlayerBase player;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private PlayerShootingSO playerShootingParameters;
    private float timer;
    private bool canShoot = true;
    private const float destroyAfterSeconds = 3f;
    [SerializeField]
    private int normalShootDamage;

    private void Awake()
    {
        timer = playerShootingParameters.shootingDelay;
        player = GetComponent<PlayerBase>();
        player.playerInput.OnShootMissilePressed += ShootMissile;
        player.playerInput.OnShootRaycastPressed += ShootRaycast;
    }

    private void ShootRaycast(object sender, EventArgs e)
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition2D();
        WeaponTracer.Create(shotPoint.position, mousePosition);
        BulletRaycast.Shoot(shotPoint.position, mousePosition, normalShootDamage);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = playerShootingParameters.shootingDelay;
            canShoot = true;
        }

    }

    private void ShootMissile(object sender, EventArgs e)
    {
        if (canShoot) {
            Vector3 shootDir = (UtilsClass.GetMouseWorldPosition2D() - shotPoint.position).normalized;
            Transform projectileTransform = InstantiateProjectile(playerShootingParameters.normalProjectilePrefab, shotPoint.position, Quaternion.identity);
            CalculateProjectileSpeed(projectileTransform, shootDir, playerShootingParameters.projectileSpeed);
            canShoot = false;
        }
    }

    private Transform InstantiateProjectile(Transform projectilePrefab, Vector3 shootPosition, Quaternion rotation)
    { 
        Transform ProjectileTransform = Instantiate(projectilePrefab, shootPosition, rotation);
        Destroy(ProjectileTransform.gameObject, destroyAfterSeconds);
        return ProjectileTransform;
    }

    private void CalculateProjectileSpeed(Transform projectileTransform, Vector3 shootDir, float projectileSpeed)
    {
        projectileTransform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(shootDir));
        projectileTransform.GetComponent<Rigidbody2D>().velocity = shootDir * projectileSpeed;
    }

    
}
