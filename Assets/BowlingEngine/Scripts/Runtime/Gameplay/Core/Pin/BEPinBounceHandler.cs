using BowlingEngine.Gameplay.Core.Ball;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinBounceHandler
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

        public void TryBounce(Collision collision)
        {
            if (collision.rigidbody != null && collision.rigidbody.TryGetComponent(out BEBallView _))
            {
                _state.StateType = BEPinStateType.Bounce;

                foreach (var collider in _view.GetComponentsInChildren<Collider>())
                {
                    Physics.IgnoreCollision(collider, collision.collider);

                    collider.material.bounciness = 0.6f;
                    collider.material.bounceCombine = PhysicsMaterialCombine.Maximum;
                }

                Vector3[] randomDirections = new Vector3[]
                {
                    _view.transform.forward,
                    _view.transform.right,
                    -_view.transform.right,
                    _view.transform.forward + _view.transform.right,
                    _view.transform.forward - _view.transform.right
                };

                _view.AddForce(
                    _view.transform.up * 1
                    + randomDirections[Random.Range(0, randomDirections.Length)] * 1);
            }
        }
    }
}
