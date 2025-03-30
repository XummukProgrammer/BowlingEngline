using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinView : MonoBehaviour
    {
        public float Mass
        {
            get => _rigidBody.mass;
            set => _rigidBody.mass = value;
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private Rigidbody _rigidBody;
        private BEPinBounceHandler _bounceHandler;

        [Inject]
        public void Construct(BEPinBounceHandler bounceHandler)
        {
            _bounceHandler = bounceHandler;
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void AddForce(Vector3 force)
        {
            _rigidBody.AddForce(force, ForceMode.Impulse);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _bounceHandler.TryBounce(collision);
        }
    }
}
