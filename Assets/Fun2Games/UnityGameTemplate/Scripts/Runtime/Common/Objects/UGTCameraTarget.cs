using UnityEngine;
using UnityGameTemplate.Camera.Services;
using Zenject;

namespace UnityGameTemplate.Common.Objects
{
    public class UGTCameraTarget : MonoBehaviour
    {
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
