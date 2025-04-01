using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Ball.States;
using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.Services.Input;
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
        private readonly BEIInput _input;
        private readonly BEBallFacade _ballFacade;

        public BECoreGameplayStatesStepFrame(
            BECoreGameplayStatesService statesService, 
            SignalBus signalBus,
            BECoreGameplayFrameData frameData,
            BEIInput input,
            BEBallFacade ballFacade)
        {
            _statesService = statesService;
            _signalBus = signalBus;
            _frameData = frameData;
            _input = input;
            _ballFacade = ballFacade;
        }

        public void Enter()
        {
            Debug.Log("A step is expected...");

            _signalBus.Subscribe<BEBallWorkedSignal>(OnBallWorked);

            _input.Enable = true;

            _ballFacade.States.EnterState<BEBallStatesBoostrap>();
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<BEBallWorkedSignal>(OnBallWorked);

            _input.Enable = false;

            _ballFacade.States.EnterState<BEBallStatesDisable>();
        }

        private void OnBallWorked()
        {
            _frameData.StepsCount--;

            _statesService.EnterState<BECoreGameplayStatesCheckFrame>();
        }
    }
}
