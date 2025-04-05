using BowlingEngine.Gameplay.Core.Objects.Ball;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesGenerate
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEAimStates _states;
        private readonly BEAimView _view;
        private readonly BEBallView _ballView;

        public BEAimStatesGenerate(
            BEAimStates states, 
            BEAimView view,
            BEBallView ballView)
        {
            _states = states;
            _view = view;
            _ballView = ballView;
        }

        public void Enter()
        {
            _view.LastPointXPosition = _ballView.Facade.TorsionFactor;
            _view.SecondPointYPosition = 2;

            _states.EnterState<BEAimStatesStay>();
        }

        public void Exit()
        {
        }
    }
}
