using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Services;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesCheckParty
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayPartyData _partyData;
        private readonly BECoreGameplayModel _gameplayModel;

        public BECoreGameplayStatesCheckParty(
            BECoreGameplayStatesService statesService,
            BECoreGameplayPartyData partyData,
            BECoreGameplayModel gameplayModel)
        {
            _statesService = statesService;
            _partyData = partyData;
            _gameplayModel = gameplayModel;
        }

        public void Enter()
        {
            int perfectFrames = _gameplayModel.MaxFrames - _partyData.FramesCount;
            Debug.Log($"The game frame is completed ({perfectFrames}/{_gameplayModel.MaxFrames}).");

            if (_partyData.FramesCount == 0)
            {
                _statesService.EnterState<BECoreGameplayStatesFinishParty>();
            }
            else
            {
                _statesService.EnterState<BECoreGameplayStatesStartFrame>();
            }
        }

        public void Exit()
        {
        }
    }
}
