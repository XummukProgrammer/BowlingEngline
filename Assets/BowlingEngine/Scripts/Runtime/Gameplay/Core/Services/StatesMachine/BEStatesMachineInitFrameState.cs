using UGT.Basic.Data;
using UGT.Common.States;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineInitFrameState
        : UGTGameplayChangerableState<BEStatesMachineService, BEStatesMachineUnloadState>
    {
        public BEStatesMachineInitFrameState(
            UGTBasicData basicData, 
            BEStatesMachineService statesMachineService) 
            : base(basicData, 
                  statesMachineService)
        {
        }
    }
}
