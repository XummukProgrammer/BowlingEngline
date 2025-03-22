using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.StaticData.Gameplay;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineLoadCoreGameplayState : CommonStatesMachineLoadGameplayState
    {
        public CommonStatesMachineLoadCoreGameplayState(
            AssetsLoaderService assetsLoaderService, 
            GameplayContainerStaticData gameplayContainerStaticData) 
            : base(assetsLoaderService, gameplayContainerStaticData)
        {
        }

        protected override GameplayTypeStaticData GetGameplayType()
        {
            return GameplayTypeStaticData.Core;
        }
    }
}
