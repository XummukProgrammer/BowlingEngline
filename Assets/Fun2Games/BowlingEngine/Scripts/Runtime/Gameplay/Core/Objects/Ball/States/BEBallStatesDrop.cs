using BowlingEngine.Gameplay.Core.Objects.Aim;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesDrop
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEBallView _view;
        private readonly BEAimView _aimView;

        public BEBallStatesDrop(BEBallView view, BEAimView aimView)
        {
            _view = view;
            _aimView = aimView;
        }

        public void Enter()
        {
            _view.Follow = _aimView.Spline;
        }

        public void Exit()
        {
        }
    }
}
