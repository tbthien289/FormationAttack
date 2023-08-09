using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.2f;

    private void Update()
    {
        if (target != null)
        {
            Vector3 nextPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, nextPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
