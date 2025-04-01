using Unity.Cinemachine;
using UnityEngine;
using UnityGameTemplate.Camera.Services;
using Zenject;

namespace UnityGameTemplate.Camera.Objects
{
    public class UGTCameraFacade : MonoBehaviour
    {
        public Transform Target
        {
            get => _cinemachineCamera.Target.TrackingTarget;
            set => _cinemachineCamera.Target.TrackingTarget = value;
        }

        private UGTCameraService _cameraService;
        private CinemachineCamera _cinemachineCamera;

        [Inject]
        public void Construct(
            UGTCameraService cameraService,
            CinemachineCamera cinemachineCamera)
        {
            _cameraService = cameraService;
            _cinemachineCamera = cinemachineCamera;
        }

        private void Awake()
        {
            _cameraService.CameraFacade = this;
        }
    }
}
