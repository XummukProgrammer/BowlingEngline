using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinPhysicsInitializer : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.mass = 0.4f;
        }
    }
}
