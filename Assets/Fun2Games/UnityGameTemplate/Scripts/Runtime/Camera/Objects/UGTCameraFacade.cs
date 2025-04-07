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

        public Vector3 FollowOffset
        {
            get => _cinemachineFollow.FollowOffset;
            set => _cinemachineFollow.FollowOffset = value;
        }

        private UGTCameraService _cameraService;
        private CinemachineCamera _cinemachineCamera;
        private CinemachineFollow _cinemachineFollow;

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
            _cinemachineFollow = _cinemachineCamera.GetComponent<CinemachineFollow>();
        }
    }
}
