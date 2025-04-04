using UnityGameTemplate.Common.States;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.UI.Windows.Services;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesLoad
        : UGTStatesLoad<UGTStarterStatesService, UGTStarterResourcesLoaderService, UGTStarterStatesGameplayLoad>
    {
        public UGTStarterStatesLoad(
            UGTStarterStatesService statesService,
            UGTStarterResourcesLoaderService resourcesLoaderService, 
            UGTWindowContainerService windowContainerService) 
            : base(statesService, 
                  resourcesLoaderService, 
                  windowContainerService)
        {
        }

        protected override void OnAfterLoad()
        {
        }
    }
}
