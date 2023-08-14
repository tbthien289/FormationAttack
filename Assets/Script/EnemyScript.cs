using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10.0f;

    private GameObject target; // The GameObject to shoot at

    public float shootingInterval = 1.0f; // Time interval between shots in seconds
    private float lastShotTime;
    public float shootingRange = 5.0f; // Maximum shooting range


    // Moving feature
    public float maxWaypointDistance = 3.0f; // Maximum distance from the starting point
    private Vector2 currentWaypoint;
    private bool hasReachedWaypoint = true;

    // Follow feature
    private bool isKite = false;
    private bool isFollowing = false;
    private float followRange = 5.0f; // Range to start following the target object
    private float returnRange = 2.0f; // Range to start returning to starting point
    private float kiteRange = 2.0f; // Range to keep between this and target

    // Main
    private Rigidbody2D rb;
    private Stats stats;
    private Vector2 startPosition;
    private float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        startPosition = transform.position;

        GenerateWaypoint();

        // Find the target GameObject by its name
        target = GameObject.Find("MainPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        // Range Move
        if (!isFollowing)
        {
            MoveToWaypoint();
            if (hasReachedWaypoint)
            {
                GenerateWaypoint();
            }

            // Check if the target is within follow range
            if (target != null && Vector2.Distance(transform.position, target.transform.position) < followRange)
            {
                isFollowing = true;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, target.transform.position) <=  kiteRange)
            {
                isKite = true;
            } else {
                isKite = false;
            }

            if (isKite) {
                KiteTarget();
            } else {
                FollowTarget();
            }

            // Return to starting point if target is out of return range
            if (Vector2.Distance(transform.position, startPosition) > returnRange)
            {
                ReturnToStartingPoint();
                isFollowing = false;
                isKite = false;
            }
        }


        // EnemyShoot
        if (target != null && Vector2.Distance(transform.position, target.transform.position) <= shootingRange)
        {
            if (Time.time - lastShotTime >= shootingInterval)
            {
                EnemyShoot();
                lastShotTime = Time.time;
            }
        }


    }

    private void GenerateWaypoint()
    {
        Vector2 randomOffset = Random.insideUnitCircle * maxWaypointDistance;
        currentWaypoint = (Vector2)startPosition + randomOffset;

        hasReachedWaypoint = false;
    }

    private void MoveToWaypoint()
    {
        if (hasReachedWaypoint)
            return;

        transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentWaypoint) < 0.1f)
        {
            hasReachedWaypoint = true;
        }
    }

    private void FollowTarget()
    {
        if (target == null)
            return;

        // Move towards the target object
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    private void KiteTarget()
    {
        if (target == null)
            return;

        Vector2 directionToTarget = target.transform.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        Vector2 newPosition = Vector2.MoveTowards(transform.position, (Vector2)transform.position - directionToTarget, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    private void ReturnToStartingPoint()
    {
        // Move towards the starting point
        transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
    }

    void EnemyShoot() // shoot 100% 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<BulletScript>().target = target;
        bullet.GetComponent<BulletScript>().damage = stats.currentDamage;
    }

    void EnemyShootDirection()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = (target.transform.position - firePoint.position).normalized * bulletSpeed;
    }

}
