using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.Common.States;
using UnityGameTemplate.UI.Windows.Services;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesLoad
        : UGTStatesLoad<BECoreGameplayStatesService, BECoreGameplayResourcesLoaderService, BECoreGameplayStatesStartParty>
    {
        public BECoreGameplayStatesLoad(
            BECoreGameplayStatesService statesService, 
            BECoreGameplayResourcesLoaderService resourcesLoaderService, 
            UGTWindowContainerService windowContainerService) 
            : base(statesService, 
                  resourcesLoaderService, 
                  windowContainerService)
        {
        }
    }
}
