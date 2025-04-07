using BowlingEngine.Gameplay.Core.Objects.Trigger.Data;
using BowlingEngine.Gameplay.Core.Objects.Trigger.Models;
using BowlingEngine.Gameplay.Core.Signals;
using Dreamteck.Splines;
using System;
using UnityEngine;
using UnityGameTemplate.Camera.Services;
using UnityGameTemplate.Sounds.Services;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Trigger.Handlers
{
    public abstract class BETriggerHandler
        : IInitializable
        , IDisposable
    {
        protected abstract BETriggerHandlerStepsModel StepsModel { get; }

        private readonly BETriggerData _data;
        private readonly SignalBus _signalBus;
        private readonly UGTCameraService _cameraService;
        private readonly UGTSoundsService _soundsService;

        public BETriggerHandler(
            BETriggerData data, 
            SignalBus signalBus,
            UGTCameraService cameraService,
            UGTSoundsService soundsService)
        {
            _data = data;
            _signalBus = signalBus;
            _cameraService = cameraService;
            _soundsService = soundsService;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<BEUserTriggeredSignal>(OnUserTriggered);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<BEUserTriggeredSignal>(OnUserTriggered);
        }

        private void OnUserTriggered(BEUserTriggeredSignal signal)
        {
            if (StepsModel != null && IsNecessaryUser(signal.User))
            {
                _data.Step++;

                var stepModel = StepsModel.GetStep(_data.Step);

                if (stepModel != null)
                {
                    foreach (var stepActionModel in stepModel.Actions)
                    {
                        ApplyStepAction(stepActionModel);
                    }
                }
            }
        }

        private void ApplyStepAction(BETriggerHandlerStepActionModel stepActionModel)
        {
            switch (stepActionModel.Type)
            {
                case BETriggerHandlerStepActionType.Speed:
                    ChangeSpeed(stepActionModel.FloatValue);
                    break;

                case BETriggerHandlerStepActionType.CameraOffset:
                    ChangeCameraOffset(stepActionModel.Vector3Value);
                    break;

                case BETriggerHandlerStepActionType.Sound:
                    PlaySound(stepActionModel.StringValue);
                    break;
            }
        }

        protected abstract bool IsNecessaryUser(SplineUser user);

        protected abstract void ChangeSpeed(float speed);

        protected virtual void ChangeCameraOffset(Vector3 offset)
        {
            _cameraService.FollowOffset = offset;
        }

        private void PlaySound(string soundID)
        {
            _soundsService.PlaySound(soundID);
        }
    }
}
