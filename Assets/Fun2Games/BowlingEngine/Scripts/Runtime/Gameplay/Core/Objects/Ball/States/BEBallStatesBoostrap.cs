using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Objects.Spawns;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private BEBallView _view;
        private BEBallSpawn _spawn;
        private BECoreGameplayModel _gameplayModel;
        private BECoreGameplayFrameData _frameData;

        public BEBallStatesBoostrap(
            BEBallView view, 
            BEBallSpawn spawn,
            BECoreGameplayModel gameplayModel,
            BECoreGameplayFrameData frameData)
        {
            _view = view;
            _spawn = spawn;
            _gameplayModel = gameplayModel;
            _frameData = frameData;
        }

        public void Enter()
        {
            var ballModel = _gameplayModel.GetBall(_frameData.BallID);
            if (ballModel == null)
            {
                return;
            }

            _view.SetSkin(ballModel.SkinID);

            _view.Facade.Health = ballModel.Health;
            _view.Facade.MaxHealth = ballModel.Health;

            _view.Facade.Speed = ballModel.Speed;
            _view.Facade.MaxSpeed = ballModel.Speed;

            _view.Position = _spawn.Position;
            _view.Quaternion = _spawn.Quaternion;

            _view.IsKinematic = false;

            _view.Facade.UpForceForPin = ballModel.UpForceForPin;
            _view.Facade.ForwardForceForPin = ballModel.ForwardForceForPin;
            _view.Facade.DirForceForPin = ballModel.DirForceForPin;

            _view.Facade.States.EnterState<BEBallStatesMove>();
        }

        public void Exit()
        {
        }
    }
}
