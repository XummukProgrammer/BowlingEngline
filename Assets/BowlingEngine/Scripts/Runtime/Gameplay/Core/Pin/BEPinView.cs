using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinView : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void AddForce(Vector3 force)
        {
            _rigidBody.AddForce(force, ForceMode.Impulse);
        }
    }
}
