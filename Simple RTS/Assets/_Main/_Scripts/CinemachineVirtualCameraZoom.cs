using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace Synith
{
    /// <summary>
    /// Listens to a CameraMover to update the zoom level of a CinemachineVirtualCamera
    /// </summary>
    public class CinemachineVirtualCameraZoom : MonoBehaviour
    {
        [SerializeField] CameraMover cameraMover;
        [SerializeField] float zoomMin = 20f;
        [SerializeField] float zoomMax = 60f;

        CinemachineVirtualCamera virtualCamera;
        CinemachineFramingTransposer framingTransposer;

        void Awake()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }

        void Start()
        {
            cameraMover.OnZoomDistanceChanged += CameraMover_OnZoomLevelChanged;
        }

        void CameraMover_OnZoomLevelChanged(object sender, float zoomLevelNormalized)
        {
            framingTransposer.m_CameraDistance = Mathf.Lerp(zoomMin, zoomMax, zoomLevelNormalized);
        }
    }
}
