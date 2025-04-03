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
        }

        private void OnSplineEnded()
        {
            _view.Unfollow();

            _view.IsKinematic = false;

            _signalBus.Fire<BEBallWorkedSignal>();
        }
    }
}
