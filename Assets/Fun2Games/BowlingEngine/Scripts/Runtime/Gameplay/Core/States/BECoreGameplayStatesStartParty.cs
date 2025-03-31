using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Services;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesStartParty
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayPartyData _partyData;
        private readonly BECoreGameplayModel _gameplayModel;

        public BECoreGameplayStatesStartParty(
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
            _partyData.FramesCount = _gameplayModel.MaxFrames;
            _partyData.Score = 0;

            Debug.Log("The game party has been launched.");
            Debug.Log($"Frames Count - {_partyData.FramesCount}");

            _statesService.EnterState<BECoreGameplayStatesStartFrame>();
        }

        public void Exit()
        {
        }
    }
}
