using System;
using UnityEngine;

namespace Synith
{
    /// <summary>
    /// CameraMover
    /// </summary>
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] float zoomSpeed = 5f;
        float zoomDistance;
        bool isRotating;

        public event EventHandler<float> OnZoomDistanceChanged;
        public event EventHandler<bool> OnRotationChanged;

        void Awake()
        {
            zoomDistance = 1f;
        }

        void Start()
        {
            OnRotationChanged?.Invoke(this, isRotating);
        }

        void Update()
        {
            HandleMovement();
            HandleZoom();
            HandleRotation();
        }

        void HandleMovement()
        {
            Vector3 movementDirection = CalculateMovementDirection();

            if (movementDirection == Vector3.zero) { return; }

            float speed = moveSpeed;
            Vector3 velocity = movementDirection * speed * Time.deltaTime;

            transform.position += velocity;
        }

        void HandleRotation()
        {
            bool isRotating = InputManager.Instance.IsRotating();
            bool rotationChanged = this.isRotating != isRotating;
            if (!rotationChanged) { return; }

            this.isRotating = isRotating;
            OnRotationChanged?.Invoke(this, isRotating);
        }

        Vector3 CalculateMovementDirection()
        {
            // Get the input from the player
            // return the direction of the input as a vector3
            Vector3 movementDirection = Vector3.zero;

            Vector2 inputVector = InputManager.Instance.GetMoveInput();

            float horizontal = inputVector.x;
            float vertical = inputVector.y;

            movementDirection += Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized * horizontal;
            movementDirection += Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized * vertical;

            return movementDirection;
        }

        void HandleZoom()
        {
            float zoomDelta = InputManager.Instance.GetZoomDelta();
            UpdateZoomDistance(zoomDelta);
        }
        void UpdateZoomDistance(float zoomDelta)
        {
            if (zoomDelta == 0) { return; }

            zoomDistance -= zoomDelta * zoomSpeed * Time.deltaTime;
            zoomDistance = Mathf.Clamp01(zoomDistance);

            OnZoomDistanceChanged?.Invoke(this, zoomDistance);
            print($"zoom delta: {zoomDelta}, zoom distance: {zoomDistance}");
        }

    }
}
