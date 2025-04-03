using BowlingEngine.Gameplay.Core.Objects.Aim;
using BowlingEngine.Gameplay.Core.Objects.Pin;
using BowlingEngine.Gameplay.Core.Signals;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesDrop
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private bool _ignoreAllCollisions;

        private readonly BEBallView _view;
        private readonly BEAimView _aimView;
        private readonly SignalBus _signalBus;
        private readonly BEPinRegistry _pinRegistry;

        public BEBallStatesDrop(
            BEBallView view, 
            BEAimView aimView,
            SignalBus signalBus,
            BEPinRegistry pinRegistry)
        {
            _view = view;
            _aimView = aimView;
            _signalBus = signalBus;
            _pinRegistry = pinRegistry;
        }

        public void Enter()
        {
            _view.SetFollow(_aimView.Spline);
            _view.FollowerSpeed = _view.Facade.Speed;

            _view.Facade.SplineEnded += OnSplineEnded;

            _view.IsKinematic = true;

            _ignoreAllCollisions = false;
        }

        public void Exit()
        {
            _view.Facade.SplineEnded -= OnSplineEnded;
        }

        public void Tick()
        {
            if (!_ignoreAllCollisions && _view.Facade.Health <= 0)
            {
                foreach (var pinFacade in _pinRegistry.Pins)
                {
                    pinFacade.View.IgnoreCollision(_view.Collider);
                }

                _ignoreAllCollisions = true;
            }

            _view.Facade.Speed = ((float)_view.Facade.Health / (float)_view.Facade.MaxHealth) * _view.Facade.MaxSpeed;
            _view.FollowerSpeed = _view.Facade.Speed;

            if (_view.Facade.Speed <= 0)
            {
                OnSplineEnded();
            }
        }

        private void OnSplineEnded()
        {
            _view.Unfollow();

            _signalBus.Fire<BEBallWorkedSignal>();

            _view.Facade.States.EnterState<BEBallStatesDisable>();
        }
    }
}
