using BowlingEngine.Gameplay.Core.Objects.Data;
using BowlingEngine.Gameplay.Core.Objects.Trigger.Data;
using BowlingEngine.Gameplay.Core.Objects.Trigger.Handlers;
using BowlingEngine.Gameplay.Core.Objects.Trigger.Models;
using Dreamteck.Splines;
using UnityGameTemplate.Camera.Services;
using UnityGameTemplate.Sounds.Services;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallTriggerHandler : BETriggerHandler
    {
        protected override BETriggerHandlerStepsModel StepsModel => _view.Facade.StepsModel;

        private readonly BEBallView _view;
        private readonly BESpeedData _speedData;

        public BEBallTriggerHandler(
            BETriggerData data, 
            SignalBus signalBus,
            BEBallView view,
            BESpeedData speedData,
            UGTCameraService cameraService,
            UGTSoundsService soundsService) 
            : base(data, 
                  signalBus,
                  cameraService,
                  soundsService)
        {
            _view = view;
            _speedData = speedData;
        }

        protected override bool IsNecessaryUser(SplineUser user)
        {
            return _view.SplineUser == user;
        }

        protected override void ChangeSpeed(float speed)
        {
            _speedData.Value = speed;
            _speedData.MaxValue = speed;
        }
    }
}
