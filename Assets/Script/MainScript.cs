using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10.0f;
    public float shootingInterval = 2.0f;
    public bool canShoot = true;

    public GameObject target;

    private Rigidbody2D rb;
    private float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 moveVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        rb.velocity = moveVelocity;

        // Find target
        target = FindClosestObject("Enemy");

        // PlayerShoot
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            canShoot = false;
            Invoke("ResetShootCooldown", shootingInterval);
        }
    }

    void ResetShootCooldown()
    {
        canShoot = true;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletScript>().target = target;
    }

    private GameObject FindClosestObject(string tag)
    {
        GameObject[] objectsToCheck = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject obj in objectsToCheck)
        {
            float distanceToPlayer = Vector3.Distance(obj.transform.position, transform.position);

            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                closestObject = obj;
            }
        }
        return closestObject;
    }
}
