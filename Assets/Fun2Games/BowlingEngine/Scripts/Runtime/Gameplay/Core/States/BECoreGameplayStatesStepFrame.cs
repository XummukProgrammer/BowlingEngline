using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Objects.Aim;
using BowlingEngine.Gameplay.Core.Objects.Aim.States;
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
        private readonly BEAimFacade _aimFacade;

        public BECoreGameplayStatesStepFrame(
            BECoreGameplayStatesService statesService, 
            SignalBus signalBus,
            BECoreGameplayFrameData frameData,
            BEIInput input,
            BEBallFacade ballFacade,
            BEAimFacade aimFacade)
        {
            _statesService = statesService;
            _signalBus = signalBus;
            _frameData = frameData;
            _input = input;
            _ballFacade = ballFacade;
            _aimFacade = aimFacade;
        }

        public void Enter()
        {
            Debug.Log("A step is expected...");

            _signalBus.Subscribe<BEBallWorkedSignal>(OnBallWorked);

            _input.Enable = true;

            _ballFacade.States.EnterState<BEBallStatesBoostrap>();
            _aimFacade.States.EnterState<BEAimStatesBoostrap>();
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<BEBallWorkedSignal>(OnBallWorked);

            _input.Enable = false;

            _ballFacade.States.EnterState<BEBallStatesDisable>();
            _aimFacade.States.EnterState<BEAimStatesDisable>();
        }

        private void OnBallWorked()
        {
            _frameData.StepsCount--;

            _statesService.EnterState<BECoreGameplayStatesCheckFrame>();
        }
    }
}
