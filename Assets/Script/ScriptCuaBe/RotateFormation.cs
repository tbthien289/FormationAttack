using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFormation : MonoBehaviour
{
    [SerializeField] private KeyCode keyRotateLeft;
    [SerializeField] private KeyCode keyRotateRight;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        if (Input.GetKey(keyRotateLeft))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.fixedDeltaTime);
        } else if (Input.GetKey(keyRotateRight))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.fixedDeltaTime);
        }
    }
}
