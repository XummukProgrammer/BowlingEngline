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
            ObjectsLoaderService objectsLoaderService, 
            CommonStatesMachineService commonStatesMachineService) 
            : base(assetsLoaderService, 
                  gameplayContainerStaticData, 
                  objectsLoaderService, 
                  commonStatesMachineService)
        {
        }

        protected override GameplayTypeStaticData GetGameplayType()
        {
            return GameplayTypeStaticData.Core;
        }
    }
}
