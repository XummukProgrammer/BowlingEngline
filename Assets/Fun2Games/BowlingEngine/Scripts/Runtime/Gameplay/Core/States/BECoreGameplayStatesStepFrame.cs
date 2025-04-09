using BowlingEngine.Common.UI.HUD.InfoHUD;
using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Objects.Aim;
using BowlingEngine.Gameplay.Core.Objects.Aim.States;
using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Ball.States;
using BowlingEngine.Gameplay.Core.Objects.Pin;
using BowlingEngine.Gameplay.Core.Objects.PinSpawner;
using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.Services.Input;
using BowlingEngine.Gameplay.Core.Signals;
using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesStepFrame
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private bool _startedChangeState;
        private float _timeForChangeState;

        private readonly BECoreGameplayStatesService _statesService;
        private readonly SignalBus _signalBus;
        private readonly BECoreGameplayFrameData _frameData;
        private readonly BEIInput _input;
        private readonly BEBallFacade _ballFacade;
        private readonly BEAimFacade _aimFacade;
        private readonly BEPinSpawner _pinSpawner;
        private readonly BEPinRegistry _pinRegistry;
        private readonly BECoreGameplayPartyData _partyData;
        private readonly BECoreGameplayModel _gameplayModel;
        private readonly BEInfoHUDService _infoHUDService;

        public BECoreGameplayStatesStepFrame(
            BECoreGameplayStatesService statesService, 
            SignalBus signalBus,
            BECoreGameplayFrameData frameData,
            BEIInput input,
            BEBallFacade ballFacade,
            BEAimFacade aimFacade,
            BEPinSpawner pinSpawner,
            BEPinRegistry pinRegistry,
            BECoreGameplayPartyData partyData,
            BECoreGameplayModel gameplayModel,
            BEInfoHUDService infoHUDService)
        {
            _statesService = statesService;
            _signalBus = signalBus;
            _frameData = frameData;
            _input = input;
            _ballFacade = ballFacade;
            _aimFacade = aimFacade;
            _pinSpawner = pinSpawner;
            _pinRegistry = pinRegistry;
            _partyData = partyData;
            _gameplayModel = gameplayModel;
            _infoHUDService = infoHUDService;
        }

        public void Enter()
        {
            Debug.Log("A step is expected...");

            _startedChangeState = false;
            _timeForChangeState = 0;

            _signalBus.Subscribe<BEBallWorkedSignal>(OnBallWorked);
            _signalBus.Subscribe<BEPinBounceSignal>(OnPinBounce);

            _input.Enable = true;

            _ballFacade.States.EnterState<BEBallStatesBoostrap>();
            _aimFacade.States.EnterState<BEAimStatesBoostrap>();

            foreach (var pin in _partyData.PartyModel.Pins)
            {
                if (!_partyData.RemovedPins.Contains((pin.X, pin.Y)))
                {
                    _pinSpawner.Spawn(pin.ID, pin.X, pin.Y);
                }
            }

            _infoHUDService.CurrentTextType = BEInfoHUDTextType.FrameStep;
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<BEBallWorkedSignal>(OnBallWorked);
            _signalBus.Unsubscribe<BEPinBounceSignal>(OnPinBounce);

            _input.Enable = false;

            _ballFacade.States.EnterState<BEBallStatesDisable>();
            _aimFacade.States.EnterState<BEAimStatesDisable>();

            var clonePins = new List<BEPinFacade>(_pinRegistry.Pins);
            foreach (var pinFacade in clonePins)
            {
                pinFacade.Dispose();
            }

            _infoHUDService.CurrentTextType = BEInfoHUDTextType.None;
        }

        public void Tick()
        {
            if (_startedChangeState)
            {
                _timeForChangeState -= Time.deltaTime;

                if (_timeForChangeState <= 0)
                {
                    _startedChangeState = false;
                    _statesService.EnterState<BECoreGameplayStatesCheckFrame>();
                }
            }
        }

        private void OnBallWorked()
        {
            _frameData.StepsCount--;

            _startedChangeState = true;
            _timeForChangeState = _gameplayModel.DelayAfterStep;
        }

        private void OnPinBounce(BEPinBounceSignal signal)
        {
            Debug.Log($"The pin with coordinates ({signal.X}, {signal.Y}) has been removed.");
            _partyData.RemovedPins.Add((signal.X, signal.Y));
        }
    }
}
