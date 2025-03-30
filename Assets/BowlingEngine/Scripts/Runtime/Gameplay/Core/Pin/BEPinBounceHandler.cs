using BowlingEngine.Gameplay.Core.Ball;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinBounceHandler : MonoBehaviour
    {
        private BEPinView _view;
        private BEPinState _state;

        [Inject]
        public void Construct(
            BEPinView view,
            BEPinState state)
        {
            _view = view;
            _state = state;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody != null && collision.rigidbody.TryGetComponent(out BEBallView _))
            {
                _state.StateType = BEPinStateType.Bounce;

                foreach (var collider in GetComponentsInChildren<Collider>())
                {
                    Physics.IgnoreCollision(collider, collision.collider);

                    collider.material.bounciness = 0.6f;
                    collider.material.bounceCombine = PhysicsMaterialCombine.Maximum;
                }

                Vector3[] randomDirections = new Vector3[]
                {
                    transform.forward,
                    transform.right,
                    -transform.right,
                    transform.forward + transform.right,
                    transform.forward - transform.right
                };

                _view.AddForce(
                    transform.up * 1 
                    + randomDirections[Random.Range(0, randomDirections.Length)] * 1);
            }
        }
    }
}
