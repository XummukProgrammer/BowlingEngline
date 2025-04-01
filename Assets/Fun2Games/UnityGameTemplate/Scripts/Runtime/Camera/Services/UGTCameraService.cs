using UnityEngine;
using UnityGameTemplate.Camera.Objects;

namespace UnityGameTemplate.Camera.Services
{
    public class UGTCameraService
    {
        public UGTCameraFacade CameraFacade { get; set; }

        public Transform Target
        {
            get => CameraFacade.Target;
            set => CameraFacade.Target = value;
        }
    }
}
