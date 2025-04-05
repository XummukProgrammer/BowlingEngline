using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Ball.States;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesIdentifyDir
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly BEAimStates _states;
        private readonly BEAimView _view;
        private readonly BEBallView _ballView;

        public BEAimStatesIdentifyDir(
            BEAimStates state,
            BEAimView view, 
            BEBallView ballView)
        {
            _states = state;
            _view = view;
            _ballView = ballView;
        }

        public void Enter()
        {
            _view.EnableRenderer = true;
        }

        public void Exit()
        {
            _view.EnableRenderer = false;
        }

        public void Tick()
        {
            if (_ballView.Facade.States.IsCurrentState<BEBallStatesDrop>())
            {
                _states.EnterState<BEAimStatesGenerate>();
            }
            else
            {
                _view.Position = _ballView.Position;
                _view.Quaternion = _ballView.Quaternion;
            }
        }
    }
}
