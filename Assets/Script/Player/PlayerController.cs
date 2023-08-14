using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ShootingController shootingController;
    private IncreaseArmorController increaseArmorController;
    private Stats stats;
    private GameObject target;
    private Rigidbody2D rb;

    public float shootingInterval = 2.0f;
    public float turnOnShieldInterval = 2.0f;
    public bool canShoot = true;
    public bool canTurnOnShield = true;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotateSpeed = 0.5f;
    [SerializeField] private GameObject pivotObject;
    [SerializeField] private KeyCode keyRotateLeft;
    [SerializeField] private KeyCode keyRotateRight;

    // Start is called before the first frame update
    void Start()
    {
        shootingController = this.gameObject.GetComponent<ShootingController>();
        increaseArmorController = this.gameObject.GetComponent<IncreaseArmorController>();

        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
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
        if (canShoot && Input.GetKeyDown(KeyCode.Space) && shootingController != null)
        {
            shootingController.Shoot(target, stats.currentDamage);
            canShoot = false;
            Invoke("ResetShootCooldown", shootingInterval);
        }
        // TurnOnShield
        if (canTurnOnShield && Input.GetKeyDown(KeyCode.Space) && increaseArmorController != null)
        {
            increaseArmorController.IncreaseArmor();
            canTurnOnShield = false;
            Invoke("ResetTurnOnShield", turnOnShieldInterval);
        }
    }

    void ResetShootCooldown()
    {
        canShoot = true;
    }

    void ResetTurnOnShield()
    {
        canTurnOnShield = true;
    }

}
