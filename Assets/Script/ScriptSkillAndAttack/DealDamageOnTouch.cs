using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnTouch : MonoBehaviour
{
    [SerializeField] private float damage;
    public string targetTag;

    private void OnTriggerEnter2D(Collider2D colider) {
        if (colider.gameObject.tag == targetTag) {
            var statsTarget = colider.gameObject.GetComponent<Stats>();
            statsTarget.currentHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
