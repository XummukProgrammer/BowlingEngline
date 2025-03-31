using UnityGameTemplate.Common.States;
using UnityGameTemplate.Starter.Services;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesUnload
        : UGTStatesUnload<UGTStarterStatesService, UGTStarterResourcesLoaderService, UGTStarterStatesDisable>
    {
        public UGTStarterStatesUnload(
            UGTStarterStatesService statesService, 
            UGTStarterResourcesLoaderService resourcesLoaderService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
        }
    }
}
