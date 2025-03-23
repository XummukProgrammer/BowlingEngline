using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.ObjectsLoader;
using BowlingEngine.StaticData.AssetsLoader;
using BowlingEngine.StaticData.Gameplay;

namespace BowlingEngine.CommonStates
{
    public abstract class CommonStatesMachineLoadGameplayState : CommonStatesMachineLoadState
    {
        private readonly GameplayContainerStaticData _gameplayContainerStaticData;
        private readonly CommonStatesMachineService _commonStatesMachineService;

        public CommonStatesMachineLoadGameplayState(
            AssetsLoaderService assetsLoaderService,
            GameplayContainerStaticData gameplayContainerStaticData,
            ObjectsLoaderService objectsLoaderService,
            CommonStatesMachineService commonStatesMachineService)
            : base(assetsLoaderService,
                  objectsLoaderService)
        {
            _gameplayContainerStaticData = gameplayContainerStaticData;
            _commonStatesMachineService = commonStatesMachineService;
        }

        protected override AssetsLoaderPackageStaticData GetPackageStaticData()
        {
            var gameplayType = GetGameplayType();
            return _gameplayContainerStaticData.Get(gameplayType).Package;
        }

        protected override void OnLoadFinished()
        {
            base.OnLoadFinished();

            switch (GetGameplayType())
            {
                case GameplayTypeStaticData.Meta:
                    _commonStatesMachineService.ChangeState<CommonStatesMachineMetaGameplayState>();
                    break;

                case GameplayTypeStaticData.Core:
                    _commonStatesMachineService.ChangeState<CommonStatesMachineCoreGameplayState>();
                    break;
            }
        }

        protected abstract GameplayTypeStaticData GetGameplayType();
    }
}
