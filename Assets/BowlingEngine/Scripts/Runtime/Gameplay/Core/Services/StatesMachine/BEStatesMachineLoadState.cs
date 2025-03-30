using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Services.Resources;
using UGT.Services.UI.HUD;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineLoadState : UGTBaseGameplayLoadState<BEStatesMachineService, BEStatesMachineInitFrameState>
    {
        public BEStatesMachineLoadState(
            UGTResourcesLoaderService resourcesLoaderService, 
            UGTHudContainerService hudContainerService, 
            BEStatesMachineService statesMachineService) 
            : base(resourcesLoaderService, 
                  hudContainerService, 
                  statesMachineService)
        {
        }
    }
}
