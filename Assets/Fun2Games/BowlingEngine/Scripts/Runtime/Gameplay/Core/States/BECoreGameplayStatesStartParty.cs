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

            _partyData.PartyModel = _gameplayModel.GetParty("Default");

            Debug.Log("The game party has been launched (ID: Default).");
            Debug.Log($"Frames Count - {_partyData.FramesCount}");

            Debug.Log("Pins:");

            foreach (var pin in _partyData.PartyModel.Pins)
            {
                Debug.Log($"A pin with coordinates ({pin.X}, {pin.Y}) is registered (ID: {pin.ID}).");
            }

            _statesService.EnterState<BECoreGameplayStatesStartFrame>();
        }

        public void Exit()
        {
        }
    }
}
