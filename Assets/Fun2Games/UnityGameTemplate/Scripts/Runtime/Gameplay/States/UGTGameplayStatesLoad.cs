using UnityGameTemplate.Common.States;
using UnityGameTemplate.Gameplay.Services;
using UnityGameTemplate.UI.Windows.Services;
using YG;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesLoad
        : UGTStatesLoad<UGTGameplayStatesService, UGTGameplayResourcesLoaderService, UGTGameplayStatesInProgress>
    {
        public UGTGameplayStatesLoad(
            UGTGameplayStatesService statesService, 
            UGTGameplayResourcesLoaderService resourcesLoaderService, 
            UGTWindowContainerService windowContainerService) 
            : base(statesService, 
                  resourcesLoaderService, 
                  windowContainerService)
        {
        }

        protected override void OnAfterLoad()
        {
            YG2.GameReadyAPI();

            base.OnAfterLoad();
        }
    }
}
