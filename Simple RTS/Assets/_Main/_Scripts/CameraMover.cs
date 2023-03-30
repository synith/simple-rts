using System;
using UnityEngine;

namespace Synith
{
    /// <summary>
    /// CameraMover
    /// </summary>
    public class CameraMover : MonoBehaviour
    {
        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector3 movementDirection = CalculateMovementDirection();

            if (movementDirection == Vector3.zero) { return; }

            float speed = 5f;
            Vector3 velocity = movementDirection * speed * Time.deltaTime;

            transform.position += velocity;
        }

        private Vector3 CalculateMovementDirection()
        {
            // Get the input from the player
            // return the direction of the input as a vector3
            Vector3 movementDirection = Vector3.zero;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            movementDirection += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized * horizontal;
            movementDirection += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized * vertical;

            return movementDirection;
        }
    }
}
