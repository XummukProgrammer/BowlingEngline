using UnityGameTemplate.Common.States;
using UnityGameTemplate.Starter.Services;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesLoad
        : UGTStatesLoad<UGTStarterStatesService, UGTStarterResourcesLoaderService, UGTStarterStatesGameplayInProgress>
    {
        public UGTStarterStatesLoad(
            UGTStarterStatesService statesService, 
            UGTStarterResourcesLoaderService resourcesLoaderService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
        }
    }
}
