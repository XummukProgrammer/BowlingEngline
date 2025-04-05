using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.Common.States;
using UnityGameTemplate.Gameplay.States;
using UnityGameTemplate.UI.Windows.Services;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesUnload
        : UGTStatesUnload<BECoreGameplayStatesService, BECoreGameplayResourcesLoaderService, UGTGameplayStatesDisable>
    {
        private readonly UGTWindowContainerService _windowContainerService;

        public BECoreGameplayStatesUnload(
            BECoreGameplayStatesService statesService, 
            BECoreGameplayResourcesLoaderService resourcesLoaderService,
            UGTWindowContainerService windowContainerService) 
            : base(statesService, 
                  resourcesLoaderService)
        {
            _windowContainerService = windowContainerService;
        }

        protected override void OnAfterUnload()
        {
            base.OnAfterUnload();

            _windowContainerService.CloseWindow("InfoWindow");
        }
    }
}
