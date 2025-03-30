using UGT.Services.Camera;
using UnityEngine;
using Zenject;

namespace UGT.Common.Camera
{
    public class UGTCameraTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform _head;

        private UGTCameraService _cameraService;

        [Inject]
        public void Construct(UGTCameraService cameraService)
        {
            _cameraService = cameraService;
        }

        private void OnEnable()
        {
            _cameraService.Target = _head;
        }

        private void OnDisable()
        {
            _cameraService.Target = null;
        }
    }
}
