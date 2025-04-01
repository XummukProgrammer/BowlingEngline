using BowlingEngine.Gameplay.Core.Objects.Ball;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesIdentifyDir
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private BEAimView _view;
        private BEBallView _ballView;

        public BEAimStatesIdentifyDir(
            BEAimView view, 
            BEBallView ballView)
        {
            _view = view;
            _ballView = ballView;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            _view.Position = _ballView.Position;
            _view.Quaternion = _ballView.Quaternion;
        }
    }
}
