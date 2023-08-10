using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RotateController
{
    public static void Rotating(Transform transform,GameObject pivotObject, float rotateSpeed, KeyCode keyRotateLeft, KeyCode keyRotateRight)
    {
        if (Input.GetKey(keyRotateLeft))
        {
            transform.RotateAround(pivotObject.transform.position, new Vector3(0, 0, 1), rotateSpeed);
        } else if (Input.GetKey(keyRotateRight))
        {
            transform.RotateAround(pivotObject.transform.position, new Vector3(0, 0, -1), rotateSpeed);
        }
    }
}
