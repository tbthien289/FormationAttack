using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovingController
{
    public static void Moving(Rigidbody2D rb, float moveSpeed)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 moveVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        rb.velocity = moveVelocity;
    }

}
