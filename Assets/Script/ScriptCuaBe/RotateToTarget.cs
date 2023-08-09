using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update() 
    {
        if (target != null)
        {
            // Calculate the direction from the current object's position to the target's position
            Vector2 directionToTarget = target.position - transform.position;

            // Calculate the angle to rotate the object
            float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;

            // Create a rotation quaternion from the angle
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

            // Apply the rotation to the object's transform
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}
