using UnityEngine;

namespace UGT.Common.Camera
{
    public class UGTCamera : MonoBehaviour
    {
        public Transform Target { get; set; }

        [SerializeField]
        private float _speed = 1;

        private UnityEngine.Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<UnityEngine.Camera>();
        }

        private void FixedUpdate()
        {
            if (Target != null)
            {
                _camera.transform.position = Vector3.Lerp(_camera.transform.position, Target.position, _speed);
            }
        }
    }
}
