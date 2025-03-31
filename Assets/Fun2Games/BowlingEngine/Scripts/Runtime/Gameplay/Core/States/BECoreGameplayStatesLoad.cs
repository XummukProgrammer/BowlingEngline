using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.Common.States;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesLoad
        : UGTStatesLoad<BECoreGameplayStatesService, BECoreGameplayResourcesLoaderService, BECoreGameplayStatesStartParty>
    {
        public BECoreGameplayStatesLoad(
            BECoreGameplayStatesService statesService, 
            BECoreGameplayResourcesLoaderService resourcesLoaderService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
        }
    }
}
