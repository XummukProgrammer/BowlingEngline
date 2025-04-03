using BowlingEngine.Gameplay.Core.Objects.Data;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin.States
{
    public class BEPinStatesBounce
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly BEPinView _view;
        private readonly BEPinDieHandler _dieHandler;
        private readonly BEHealthData _healthData;
        private readonly BEPinRegistry _registry;

        private float _dieTimer;
        private bool _ignoreAllCollisions;

        public BEPinStatesBounce(
            BEPinView view,
            BEPinDieHandler dieHandler,
            BEHealthData healthData,
            BEPinRegistry registry)
        {
            _view = view;
            _dieHandler = dieHandler;
            _healthData = healthData;
            _registry = registry;
        }

        public void Enter()
        {
            _dieTimer = 1;
            _ignoreAllCollisions = false;
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            _dieTimer -= Time.deltaTime;

            if (_dieTimer <= 0)
            {
                _dieHandler.Die();
            }

            if (!_ignoreAllCollisions && _healthData.Value <= 0)
            {
                foreach (var pinFacade in _registry.Pins)
                {
                    _view.IgnoreCollision(pinFacade.View.Collider);
                }

                _ignoreAllCollisions = true;
            }
        }
    }
}
