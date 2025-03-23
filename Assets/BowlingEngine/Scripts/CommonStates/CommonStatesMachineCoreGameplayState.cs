using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.StaticData.Gameplay;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineCoreGameplayState : CommonStatesMachineGameplayState
    {
        public CommonStatesMachineCoreGameplayState(
            AssetsLoaderService assetsLoaderService, 
            GameplayContainerStaticData gameplayContainerStaticData, 
            CommonStatesMachineService commonStatesMachineService) 
            : base(assetsLoaderService, 
                  gameplayContainerStaticData, 
                  commonStatesMachineService)
        {
        }

        protected override GameplayTypeStaticData GetGameplayType()
        {
            return GameplayTypeStaticData.Core;
        }
    }
}
