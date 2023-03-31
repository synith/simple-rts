using Cinemachine;
using UnityEngine;

namespace Synith
{
    /// <summary>
    /// CinemachineVirtualCameraRotate
    /// </summary>
    public class CinemachineVirtualCameraRotate : MonoBehaviour
    {
        [SerializeField] CameraMover cameraMover;
        [SerializeField] float rotationSpeed = 100f;

        CinemachineVirtualCamera virtualCamera;
        CinemachinePOV pov;

        void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        }

        void Start()
        {
            cameraMover.OnRotationChanged += CameraMover_OnRotationChanged;
        }

        void CameraMover_OnRotationChanged(object sender, bool e)
        {
            float rotationSpeed = e ? this.rotationSpeed : 0f;
            pov.m_HorizontalAxis.m_MaxSpeed = rotationSpeed;            
        }
    }
}
