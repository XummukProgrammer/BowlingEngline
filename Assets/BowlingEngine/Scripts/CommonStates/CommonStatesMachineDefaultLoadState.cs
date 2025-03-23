using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.ObjectsLoader;
using BowlingEngine.StaticData.AssetsLoader;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineDefaultLoadState : CommonStatesMachineLoadState
    {
        private readonly AssetsLoaderPackageStaticData _defaultPackageStaticData;
        private readonly CommonStatesMachineService _statesMachineService;

        public CommonStatesMachineDefaultLoadState(
            AssetsLoaderService assetsLoaderService, 
            ObjectsLoaderService objectsLoaderService,
            AssetsLoaderPackageStaticData defaultPackageStaticData,
            CommonStatesMachineService statesMachineService) 
            : base(assetsLoaderService, 
                  objectsLoaderService)
        {
            _defaultPackageStaticData = defaultPackageStaticData;
            _statesMachineService = statesMachineService;
        }

        protected override AssetsLoaderPackageStaticData GetPackageStaticData()
        {
            return _defaultPackageStaticData;
        }

        protected override void OnLoadFinished()
        {
            _statesMachineService.ChangeState<CommonStatesMachineLoadMetaGameplayState>();
        }
    }
}
