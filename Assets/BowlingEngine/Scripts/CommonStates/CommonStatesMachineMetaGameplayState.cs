using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.StaticData.Gameplay;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineMetaGameplayState : CommonStatesMachineGameplayState
    {
        public CommonStatesMachineMetaGameplayState(
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
            return GameplayTypeStaticData.Meta;
        }
    }
}
