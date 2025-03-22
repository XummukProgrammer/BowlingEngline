using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.StaticData.Gameplay;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineLoadMetaGameplayState : CommonStatesMachineLoadGameplayState
    {
        public CommonStatesMachineLoadMetaGameplayState(
            AssetsLoaderService assetsLoaderService,
            GameplayContainerStaticData gameplayContainerStaticData)
            : base(assetsLoaderService, gameplayContainerStaticData)
        {
        }

        protected override GameplayTypeStaticData GetGameplayType()
        {
            return GameplayTypeStaticData.Meta;
        }
    }
}
