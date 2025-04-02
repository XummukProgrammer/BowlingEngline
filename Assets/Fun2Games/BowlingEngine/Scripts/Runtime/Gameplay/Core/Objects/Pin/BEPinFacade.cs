using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Pin.States;
using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinFacade : MonoBehaviour, IPoolable<Vector3, IMemoryPool>, IDisposable
    {
        public BEPinStates States { get; private set; }

        private BEPinView _view;
        private BEPinRegistry _registry;
        private BEPinBounceHandler _bounceHandler;
        private BEBallView _ballView;
        private IMemoryPool _pool;

        [Inject]
        public void Construct(
            BEPinView view, 
            BEPinStates states,
            BEPinRegistry registry,
            BEPinBounceHandler bounceHandler,
            BEBallView ballView)
        {
            _view = view;
            _registry = registry;
            _bounceHandler = bounceHandler;
            _ballView = ballView;

            States = states;
        }

        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            _pool = pool;

            _view.Position = position;
            _view.Quaternion = Quaternion.identity;

            _view.AngularVelocity = Vector3.zero;
            _view.LinearVelocity = Vector3.zero;
            _view.ResetPhysics();

            _view.MaterialBounce = 0;

            _view.IgnoreCollision(_ballView.Collider, false);

            States.EnterState<BEPinStatesBoostrap>();

            _registry.AddPin(this);
        }

        public void OnDespawned()
        {
            _pool = null;

            _registry.RemovePin(this);
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.rigidbody != null && collision.rigidbody.TryGetComponent(out BEBallView _))
            {
                _bounceHandler.Bounce(collision.collider);
            }
        }
    }
}
