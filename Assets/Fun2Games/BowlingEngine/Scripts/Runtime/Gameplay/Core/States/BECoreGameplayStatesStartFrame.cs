using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Services;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesStartFrame
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayFrameData _frameData;
        private readonly BECoreGameplayPartyData _partyData;
        private readonly BECoreGameplayModel _gameplayModel;

        public BECoreGameplayStatesStartFrame(
            BECoreGameplayStatesService statesService,
            BECoreGameplayFrameData frameData,
            BECoreGameplayModel gameplayModel,
            BECoreGameplayPartyData partyData)
        {
            _statesService = statesService;
            _frameData = frameData;
            _gameplayModel = gameplayModel;
            _partyData = partyData;
        }

        public void Enter()
        {
            _frameData.StepsCount = _gameplayModel.MaxSteps;

            Debug.Log("The game frame has been launched.");
            Debug.Log($"Steps Count - {_frameData.StepsCount}");

            _partyData.ClearPins();
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    _partyData.AddPin("Default", x, y);
                    Debug.Log($"A pin with coordinates ({x}, {y}) is registered (ID: Default).");
                }
            }

            _frameData.BallID = "Default";
            Debug.Log($"The ball has an identifier set to {_frameData.BallID}.");

            _statesService.EnterState<BECoreGameplayStatesStepFrame>();
        }

        public void Exit()
        {
        }
    }
}
