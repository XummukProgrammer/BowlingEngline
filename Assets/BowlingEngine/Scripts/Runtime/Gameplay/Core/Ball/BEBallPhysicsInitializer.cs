using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallPhysicsInitializer : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _rigidBody.useGravity = false;
        }
    }
}
