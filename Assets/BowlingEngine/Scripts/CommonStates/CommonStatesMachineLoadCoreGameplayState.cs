using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.ObjectsLoader;
using BowlingEngine.StaticData.Gameplay;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineLoadCoreGameplayState : CommonStatesMachineLoadGameplayState
    {
        public CommonStatesMachineLoadCoreGameplayState(
            AssetsLoaderService assetsLoaderService, 
            GameplayContainerStaticData gameplayContainerStaticData, 
            ObjectsLoaderService objectsLoaderService) 
            : base(assetsLoaderService, 
                  gameplayContainerStaticData, 
                  objectsLoaderService)
        {
        }

        protected override GameplayTypeStaticData GetGameplayType()
        {
            return GameplayTypeStaticData.Core;
        }
    }
}
