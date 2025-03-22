using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;
using BowlingEngine.StaticData.Gameplay;
using System.Threading.Tasks;

namespace BowlingEngine.CommonStates
{
    public abstract class CommonStatesMachineLoadGameplayState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private readonly AssetsLoaderService _assetsLoaderService;
        private readonly GameplayContainerStaticData _gameplayContainerStaticData;

        public CommonStatesMachineLoadGameplayState(
            AssetsLoaderService assetsLoaderService,
            GameplayContainerStaticData gameplayContainerStaticData)
        {
            _assetsLoaderService = assetsLoaderService;
            _gameplayContainerStaticData = gameplayContainerStaticData;
        }

        public void Enter()
        {
            _ = LoadPackage();
        }

        public void Exit()
        {
            _ = UnloadPackage();
        }

        private async Task LoadPackage()
        {
            var gameplayType = GetGameplayType();
            var gameplayData = _gameplayContainerStaticData.Get(gameplayType);

            if (gameplayData != null)
            {
                foreach (var element in gameplayData.Package.Elements)
                    await _assetsLoaderService.Load(element.name, element.Path, element.Type);
            }
        }

        private async Task UnloadPackage()
        {
            var gameplayType = GetGameplayType();
            var gameplayData = _gameplayContainerStaticData.Get(gameplayType);

            if (gameplayData != null)
            {
                foreach (var element in gameplayData.Package.Elements)
                    await _assetsLoaderService.Unload(element.name);
            }
        }

        protected abstract GameplayTypeStaticData GetGameplayType();
    }
}
