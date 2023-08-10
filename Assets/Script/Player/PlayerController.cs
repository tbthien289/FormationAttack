using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ShootingController shootingController;
    private GameObject target;
    private Rigidbody2D rb;

    public float shootingInterval = 2.0f;
    public bool canShoot = true;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private GameObject pivotObject;
    [SerializeField] private KeyCode keyRotateLeft;
    [SerializeField] private KeyCode keyRotateRight;

    // Start is called before the first frame update
    void Start()
    {
        shootingController = this.gameObject.GetComponent<ShootingController>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving
        MovingController.Moving(rb, moveSpeed);
        // Rotating
        if (pivotObject != null)
        RotateController.Rotating(transform, pivotObject, rotateSpeed, keyRotateLeft, keyRotateRight);
        // Find target
        target = CommonUtils.FindClosestObject(this.gameObject, "Enemy");

        // PlayerShoot
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            shootingController.Shoot(target);
            canShoot = false;
            Invoke("ResetShootCooldown", shootingInterval);
        }
    }

    void ResetShootCooldown()
    {
        canShoot = true;
    }

}
