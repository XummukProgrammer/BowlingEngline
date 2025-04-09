using BowlingEngine.Common.UI.HUD.InfoHUD;
using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Ball.States;
using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.Services.Input;
using BowlingEngine.Gameplay.Core.Signals;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.UI.HUD.Common.Message;
using Zenject;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesSelectBall
        : UGTIEnterableState
        , UGTIExitableState
    {
        private readonly BEIInput _input;
        private readonly BEBallView _ballView;
        private readonly SignalBus _signalBus;
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayFrameData _frameData;
        private readonly BEInfoHUDService _infoHUDService;
        private readonly UGTMessageHUDService _messageHUDService;

        public BECoreGameplayStatesSelectBall(
            BEIInput input,
            BEBallView ballView,
            SignalBus signalBus,
            BECoreGameplayStatesService statesService,
            BECoreGameplayFrameData frameData,
            BEInfoHUDService infoHUDService,
            UGTMessageHUDService messageHUDService)
        {
            _input = input;
            _ballView = ballView;
            _signalBus = signalBus;
            _statesService = statesService;
            _frameData = frameData;
            _infoHUDService = infoHUDService;
            _messageHUDService = messageHUDService;
        }

        public void Enter()
        {
            _input.Enable = true;

            _ballView.Facade.States.EnterState<BEBallStatesPreview>();

            _signalBus.Subscribe<BEBallSelectSignal>(OnBallSelected);

            _infoHUDService.CurrentTextType = BEInfoHUDTextType.SelectBall;
        }

        public void Exit()
        {
            _input.Enable = false;

            _ballView.Facade.States.EnterState<BEBallStatesDisable>();

            _signalBus.Unsubscribe<BEBallSelectSignal>(OnBallSelected);

            _infoHUDService.CurrentTextType = BEInfoHUDTextType.None;
        }

        private void OnBallSelected(BEBallSelectSignal signal)
        {
            _frameData.BallID = signal.BallID;
            Debug.Log($"The ball has an identifier set to {_frameData.BallID}.");

            _statesService.EnterState<BECoreGameplayStatesStepFrame>();
        }
    }
}
