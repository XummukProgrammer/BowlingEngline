using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.Common.States;
using UnityGameTemplate.UI.Windows.Services;
using YG;

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

        protected override void OnAfterLoad()
        {
            YG2.GameReadyAPI();

            base.OnAfterLoad();
        }
    }
}
