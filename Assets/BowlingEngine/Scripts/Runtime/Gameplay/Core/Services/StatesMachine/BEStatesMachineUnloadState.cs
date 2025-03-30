using UGT.Basic.Data;
using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Services.Resources;
using UGT.Services.UI.HUD;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineUnloadState : UGTBaseGameplayUnloadState<BEStatesMachineService>
    {
        public BEStatesMachineUnloadState(
            UGTResourcesLoaderService resourcesLoaderService, 
            UGTHudContainerService hudContainerService, 
            UGTBasicData basicData) 
            : base(resourcesLoaderService, 
                  hudContainerService, 
                  basicData)
        {
        }
    }
}
