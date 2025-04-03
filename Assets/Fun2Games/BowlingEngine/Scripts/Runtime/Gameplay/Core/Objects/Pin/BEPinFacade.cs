using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Data;
using BowlingEngine.Gameplay.Core.Objects.Pin.States;
using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinFacade : MonoBehaviour, IPoolable<string, Vector2, Vector3, IMemoryPool>, IDisposable
    {
        public BEPinView View => _view;
        public BEPinStates States { get; private set; }

        public int Health
        {
            get => _healthData.Value;
            set => _healthData.Value = value;
        }

        public Vector2 Cell { get; private set; }

        private BEPinView _view;
        private BEPinRegistry _registry;
        private BEPinBounceHandler _bounceHandler;
        private BEBallView _ballView;
        private BEHealthData _healthData;
        private BECoreGameplayModel _gameplayModel;
        private IMemoryPool _pool;

        [Inject]
        public void Construct(
            BEPinView view, 
            BEPinStates states,
            BEPinRegistry registry,
            BEPinBounceHandler bounceHandler,
            BEBallView ballView,
            BEHealthData healthData,
            BECoreGameplayModel gameplayModel)
        {
            _view = view;
            _registry = registry;
            _bounceHandler = bounceHandler;
            _ballView = ballView;
            _healthData = healthData;
            _gameplayModel = gameplayModel;

            States = states;
        }

        public void OnSpawned(string id, Vector2 cell, Vector3 position, IMemoryPool pool)
        {
            _pool = pool;

            _registry.AddPin(this);

            var pinModel = _gameplayModel.GetPin(id);
            if (pinModel == null)
            {
                return;
            }

            _healthData.Value = 4;
            _healthData.MaxValue = 4;

            _view.Position = position;
            _view.Quaternion = Quaternion.identity;
            _view.Mass = pinModel.Mass;

            _view.AngularVelocity = Vector3.zero;
            _view.LinearVelocity = Vector3.zero;
            _view.ResetPhysics();

            _view.MaterialBounce = 0;

            Cell = cell;

            States.EnterState<BEPinStatesStay>();
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
            if (collision.rigidbody != null)
            {
                if (collision.rigidbody.TryGetComponent(out BEBallView _))
                {
                    _bounceHandler.BounceWithBall(collision.collider);
                }
                else if (collision.rigidbody.TryGetComponent(out BEPinView pinView))
                {
                    _bounceHandler.BounceWithPin(pinView, collision.collider);
                }
            }
        }
    }
}
