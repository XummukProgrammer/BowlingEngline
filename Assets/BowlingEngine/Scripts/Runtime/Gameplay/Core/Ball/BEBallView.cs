using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallView : MonoBehaviour
    {
        public float HorizontalDiff
        {
            get => _rigidBody.linearVelocity.x;
            set => _rigidBody.linearVelocity = new Vector3(value, 0);
        }

        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
    }
}
