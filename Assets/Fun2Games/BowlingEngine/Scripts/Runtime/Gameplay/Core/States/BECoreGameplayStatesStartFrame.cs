using BowlingEngine.Gameplay.Core.Data;
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

        public BECoreGameplayStatesStartFrame(
            BECoreGameplayStatesService statesService,
            BECoreGameplayFrameData frameData,
            BECoreGameplayPartyData partyData)
        {
            _statesService = statesService;
            _frameData = frameData;
            _partyData = partyData;
        }

        public void Enter()
        {
            _frameData.StepsCount = _partyData.PartyModel.MaxSteps;

            Debug.Log("The game frame has been launched.");
            Debug.Log($"Steps Count - {_frameData.StepsCount}");

            _partyData.RemovedPins.Clear();

            _statesService.EnterState<BECoreGameplayStatesSelectBall>();
        }

        public void Exit()
        {
        }
    }
}
