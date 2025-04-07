using BowlingEngine.Gameplay.Core.Objects.Trigger.Data;
using BowlingEngine.Gameplay.Core.Objects.Trigger.Models;
using BowlingEngine.Gameplay.Core.Signals;
using Dreamteck.Splines;
using System;
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

        public BETriggerHandler(
            BETriggerData data, 
            SignalBus signalBus)
        {
            _data = data;
            _signalBus = signalBus;
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
            }
        }

        protected abstract bool IsNecessaryUser(SplineUser user);

        protected abstract void ChangeSpeed(float speed);
    }
}
