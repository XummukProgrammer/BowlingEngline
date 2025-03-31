using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.Common.States;
using UnityGameTemplate.Gameplay.States;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesUnload
        : UGTStatesUnload<BECoreGameplayStatesService, BECoreGameplayResourcesLoaderService, UGTGameplayStatesDisable>
    {
        public BECoreGameplayStatesUnload(
            BECoreGameplayStatesService statesService, 
            BECoreGameplayResourcesLoaderService resourcesLoaderService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
        }
    }
}
