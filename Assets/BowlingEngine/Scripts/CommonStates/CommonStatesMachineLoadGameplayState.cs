using BowlingEngine.Gameplay.AssetsLoader;
using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;
using BowlingEngine.StaticData.Gameplay;
using BowlingEngine.UI.Windows.Load;
using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.CommonStates
{
    public abstract class CommonStatesMachineLoadGameplayState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private LoadWindowView _loadWindowView;

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
            _loadWindowView = GameObject.FindFirstObjectByType<LoadWindowView>();

            _ = Load();
        }

        public void Exit()
        {
            _ = UnloadPackage();
        }

        private async Task Load()
        {
            _loadWindowView.IsEnabled = true;

            await LoadPackage();
            await LoadAssets();

            await Task.Delay(3000);

            _loadWindowView.IsEnabled = false;
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

        private async Task LoadAssets()
        {
            var materialObjects =  Resources.FindObjectsOfTypeAll<MaterialAssetLoader>();
            foreach (var @object in materialObjects)
                await @object.Load();

            var prefabObjects = Resources.FindObjectsOfTypeAll<PrefabAssetLoader>();
            foreach (var @object in prefabObjects)
                await @object.Load();
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
