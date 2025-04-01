using UnityEngine;
using UnityGameTemplate.Camera.Services;
using Zenject;

namespace UnityGameTemplate.Camera.Objects
{
    public class UGTCameraFacade : MonoBehaviour
    {
        public Transform Target { get; set; }
        public Vector3 Position => Target.position;
        Quaternion Quaternion => Target.rotation;
        public float Speed { get; set; } = 0.1f;

        private UGTCameraView _view;
        private UGTCameraService _cameraService;

        [Inject]
        public void Construct(
            UGTCameraView view, 
            UGTCameraService cameraService)
        {
            _view = view;
            _cameraService = cameraService;
        }

        private void Awake()
        {
            _cameraService.CameraFacade = this;
        }

        private void Update()
        {
            if (Target != null)
            {
                _view.Position = Vector3.Lerp(_view.Position, Position, Speed);
                _view.Quaternion = Quaternion;
            }
        }
    }
}
