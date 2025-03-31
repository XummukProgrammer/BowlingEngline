using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.Signals;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesStepFrame
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly SignalBus _signalBus;
        private readonly BECoreGameplayFrameData _frameData;

        public BECoreGameplayStatesStepFrame(
            BECoreGameplayStatesService statesService, 
            SignalBus signalBus,
            BECoreGameplayFrameData frameData)
        {
            _statesService = statesService;
            _signalBus = signalBus;
            _frameData = frameData;
        }

        public void Enter()
        {
            Debug.Log("A step is expected...");

            _signalBus.Subscribe<BEBallWorkedSignal>(OnBallWorked);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<BEBallWorkedSignal>(OnBallWorked);
        }

        private void OnBallWorked()
        {
            _frameData.StepsCount--;

            _statesService.EnterState<BECoreGameplayStatesCheckFrame>();
        }
    }
}
