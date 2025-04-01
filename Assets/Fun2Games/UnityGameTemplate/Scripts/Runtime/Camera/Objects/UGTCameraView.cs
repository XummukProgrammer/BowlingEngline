using UnityEngine;

namespace UnityGameTemplate.Camera.Objects
{
    public class UGTCameraView : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Quaternion
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }
    }
}
