using UnityGameTemplate.Common.States;
using UnityGameTemplate.Gameplay.Services;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesLoad
        : UGTStatesLoad<UGTGameplayStatesService, UGTGameplayResourcesLoaderService, UGTGameplayStatesInProgress>
    {
        public UGTGameplayStatesLoad(
            UGTGameplayStatesService statesService, 
            UGTGameplayResourcesLoaderService resourcesLoaderService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
        }
    }
}
