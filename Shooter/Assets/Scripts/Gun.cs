using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet projectile;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float bulletSpeed = 35f;
    [SerializeField] private float msBetweenShoot = 100f;
    private float fireRate;
    public void Shoot() {
        if (Time.time > fireRate)
        {
            fireRate = Time.time + msBetweenShoot / 1000;
            Bullet newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Bullet;
            newProjectile.setBulletSpeed(bulletSpeed);
        }
    }
}
