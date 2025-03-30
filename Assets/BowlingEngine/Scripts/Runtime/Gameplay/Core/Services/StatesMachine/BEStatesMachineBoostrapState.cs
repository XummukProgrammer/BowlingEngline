using UGT.Common.Gameplay;
using UGT.Common.Gameplay.Services.StatesMachine;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineBoostrapState : UGTBaseGameplayBoostrapState<BEStatesMachineService, BEStatesMachineLoadState>
    {
        public BEStatesMachineBoostrapState(
            BEStatesMachineService statesMachineService, 
            UGTGameplayType gameplayType) 
            : base(statesMachineService, 
                  gameplayType)
        {
        }
    }
}
