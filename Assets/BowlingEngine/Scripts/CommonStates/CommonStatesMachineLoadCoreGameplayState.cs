using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineLoadCoreGameplayState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private readonly AssetsLoaderPackageService _assetsLoaderPackageService;

        public CommonStatesMachineLoadCoreGameplayState(AssetsLoaderPackageService assetsLoaderPackageService)
        {
            _assetsLoaderPackageService = assetsLoaderPackageService;
        }

        public void Enter()
        {
            _ = _assetsLoaderPackageService.Load();
        }

        public void Exit()
        {
        }
    }
}
