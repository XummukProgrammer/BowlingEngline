using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Objects.Spawns;
using BowlingEngine.Gameplay.Core.Objects.Trigger.Data;
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
        private readonly BETriggerData _triggerData;

        public BEBallStatesBoostrap(
            BEBallView view, 
            BEBallSpawn spawn,
            BECoreGameplayModel gameplayModel,
            BECoreGameplayFrameData frameData,
            BETriggerData triggerData)
        {
            _view = view;
            _spawn = spawn;
            _gameplayModel = gameplayModel;
            _frameData = frameData;
            _triggerData = triggerData;
        }

        public void Enter()
        {
            var ballModel = _gameplayModel.GetBall(_frameData.BallID);
            if (ballModel == null)
            {
                return;
            }

            _view.Facade.ClassID = ballModel.Class.name;

            _view.SetSkin(ballModel.SkinID);

            _view.Facade.Health = ballModel.Class.Health;
            _view.Facade.MaxHealth = ballModel.Class.Health;

            _view.Facade.Speed = ballModel.Class.Speed;
            _view.Facade.MaxSpeed = ballModel.Class.Speed;

            _view.Position = _spawn.Position;
            _view.Quaternion = _spawn.Quaternion;

            _view.IsKinematic = false;

            _view.Facade.UpForceForPin = ballModel.Class.UpForceForPin;
            _view.Facade.ForwardForceForPin = ballModel.Class.ForwardForceForPin;
            _view.Facade.DirForceForPin = ballModel.Class.DirForceForPin;

            _triggerData.Step = -1;
            _view.Facade.StepsModel = ballModel.Class.StepsModel;

            _view.Facade.CameraFollowOffset = new UnityEngine.Vector3(0, 2, -6);

            _view.Facade.States.EnterState<BEBallStatesMove>();
        }

        public void Exit()
        {
        }
    }
}
