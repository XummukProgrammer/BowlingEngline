using UnityEngine;
using UnityGameTemplate.Camera.Services;
using Zenject;

namespace UnityGameTemplate.Common.Objects
{
    public class UGTCameraTarget : MonoBehaviour
    {
        public Vector3 FollowOffset
        {
            get => _cameraService.FollowOffset;
            set => _cameraService.FollowOffset = value;
        }

        private UGTCameraService _cameraService;

        [Inject]
        public void Construct(UGTCameraService cameraService)
        {
            _cameraService = cameraService;
        }

        private void OnEnable()
        {
            _cameraService.Target = transform;
        }

        private void OnDisable()
        {
            _cameraService.Target = transform;
        }
    }
}
