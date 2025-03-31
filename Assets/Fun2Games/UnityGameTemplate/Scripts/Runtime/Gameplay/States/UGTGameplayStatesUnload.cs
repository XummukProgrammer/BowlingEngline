using UnityGameTemplate.Common.States;
using UnityGameTemplate.Gameplay.Services;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesUnload
        : UGTStatesUnload<UGTGameplayStatesService, UGTGameplayResourcesLoaderService, UGTGameplayStatesDisable>
    {
        public UGTGameplayStatesUnload(
            UGTGameplayStatesService statesService, 
            UGTGameplayResourcesLoaderService resourcesLoaderService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
        }
    }
}
