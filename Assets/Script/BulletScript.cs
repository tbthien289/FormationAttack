using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10.0f;
    public float damage;
    public GameObject target;

    // Di chuyen vien dan toi vi tri Target
    void Update()
    {
        if (target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = moveDirection * bulletSpeed;
        }
    }

    // Khi dung vao ke dich se gay dame
    private void OnTriggerEnter2D(Collider2D colider) {
        if (colider.gameObject.tag == target.tag && target.tag != null) {
            var statsTarget = colider.gameObject.GetComponent<Stats>();
            statsTarget.currentHealth -= damage * ((100f - statsTarget.currentArmor) / 100f);
            Destroy(this.gameObject);
        }
    }
}
