using UGT.Common.Camera;
using UnityEngine;
using Zenject;

namespace UGT.Services.Camera
{
    public class UGTCameraService : IInitializable
    {
        public Transform Target
        {
            get => _camera.Target;
            set => _camera.Target = value;
        }

        private UGTCamera _camera;

        public void Initialize()
        {
            _camera = GameObject.FindFirstObjectByType<UGTCamera>();
        }
    }
}
