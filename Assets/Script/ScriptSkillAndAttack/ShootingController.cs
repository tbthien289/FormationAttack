using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    private float bulletSpeed = 10.0f;
    private float shootingInterval = 2.0f;

    public void Shoot(GameObject target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletScript>().target = target;
    }

}
