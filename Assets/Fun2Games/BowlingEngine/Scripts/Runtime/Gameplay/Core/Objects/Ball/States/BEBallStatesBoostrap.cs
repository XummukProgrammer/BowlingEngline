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

            _view.Facade.Health = 3;
            _view.Facade.MaxHealth = 3;

            _view.Facade.Speed = 5;
            _view.Facade.MaxSpeed = 5;

            _view.Position = _spawn.Position;
            _view.Quaternion = _spawn.Quaternion;

            _view.IsKinematic = false;

            _view.Facade.States.EnterState<BEBallStatesMove>();
        }

        public void Exit()
        {
        }
    }
}
