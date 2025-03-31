using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesFinishFrame
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayPartyData _partyData;

        public BECoreGameplayStatesFinishFrame(
            BECoreGameplayStatesService statesService, 
            BECoreGameplayPartyData partyData)
        {
            _statesService = statesService;
            _partyData = partyData;
        }

        public void Enter()
        {
            _partyData.FramesCount--;

            _statesService.EnterState<BECoreGameplayStatesCheckParty>();
        }

        public void Exit()
        {
        }
    }
}
