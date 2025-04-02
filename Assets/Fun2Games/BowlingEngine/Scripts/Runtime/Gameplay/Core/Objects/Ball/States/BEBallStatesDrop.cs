using BowlingEngine.Gameplay.Core.Objects.Aim;
using BowlingEngine.Gameplay.Core.Signals;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesDrop
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEBallView _view;
        private readonly BEAimView _aimView;
        private readonly SignalBus _signalBus;

        public BEBallStatesDrop(
            BEBallView view, 
            BEAimView aimView,
            SignalBus signalBus)
        {
            _view = view;
            _aimView = aimView;
            _signalBus = signalBus;
        }

        public void Enter()
        {
            _view.SetFollow(_aimView.Spline);

            _view.Facade.SplineEnded += OnSplineEnded;

            _view.IsKinematic = true;
        }

        public void Exit()
        {
            _view.Facade.SplineEnded -= OnSplineEnded;
        }

        private void OnSplineEnded()
        {
            _view.Unfollow();

            _view.IsKinematic = false;

            _signalBus.Fire<BEBallWorkedSignal>();
        }
    }
}
