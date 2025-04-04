using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Services;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesCheckFrame
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayFrameData _frameData;
        private readonly BECoreGameplayPartyData _partyData;

        public BECoreGameplayStatesCheckFrame(
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
            int perfectSteps = _partyData.PartyModel.MaxSteps - _frameData.StepsCount;
            Debug.Log($"A step has been taken in the game frame ({perfectSteps}/{_partyData.PartyModel.MaxSteps}).");

            if (_frameData.StepsCount == 0)
            {
                _statesService.EnterState<BECoreGameplayStatesFinishFrame>();
            }
            else
            {
                _statesService.EnterState<BECoreGameplayStatesSelectBall>();
            }
        }

        public void Exit()
        {
        }
    }
}
