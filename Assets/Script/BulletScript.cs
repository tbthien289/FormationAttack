using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 10.0f;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colider) {
        if ((colider.gameObject.name == "MainPlayer" || colider.gameObject.tag == "Enemy") && target.tag == colider.gameObject.tag) {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = moveDirection * bulletSpeed;
        }
    }
}
