using UnityEngine;

namespace Synith
{
    /// <summary>
    /// InputManager
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        PlayerControls playerControls;
        Vector2 moveInput;
        bool isRotating;

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            DontDestroyOnLoad(gameObject);

            playerControls = new();
            playerControls.Enable();

            playerControls.Main.Rotate.started += _ => isRotating = true;
            playerControls.Main.Rotate.canceled += _ => isRotating = false;
        }

        public bool IsRotating() => isRotating;
        public Vector2 GetMoveInput() => playerControls.Main.Move.ReadValue<Vector2>();
        public float GetZoomDelta()
        {
            float zoomDelta = playerControls.Main.Zoom.ReadValue<Vector2>().y;
            return Mathf.Clamp(zoomDelta, -1f, 1f);
        }
    }
}
