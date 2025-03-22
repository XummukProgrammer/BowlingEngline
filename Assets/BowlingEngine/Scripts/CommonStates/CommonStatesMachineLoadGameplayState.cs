using BowlingEngine.Gameplay.AssetsLoader;
using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;
using BowlingEngine.StaticData.Gameplay;
using BowlingEngine.UI.Windows.Load;
using System.Linq;
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

            _loadWindowView.IsEnabled = false;
        }

        private async Task LoadPackage()
        {
            var gameplayType = GetGameplayType();
            var gameplayData = _gameplayContainerStaticData.Get(gameplayType);

            if (gameplayData != null)
            {
                var elements = gameplayData.Package.Elements;

                _loadWindowView.ChangeStatus("Загружаем пакет... (1/2)", elements.Count());

                foreach (var element in elements)
                {
                    await _assetsLoaderService.Load(element.name, element.Path, element.Type);
                    _loadWindowView.CurrentValue++;
                    await Task.Delay(1000);
                }
            }
        }

        private async Task LoadAssets()
        {
            var prefabObjects = Resources.FindObjectsOfTypeAll<PrefabAssetLoader>();

            _loadWindowView.ChangeStatus("Создаём объекты... (2/2)", prefabObjects.Length);

            foreach (var @object in prefabObjects)
            {
                await @object.Load();
                _loadWindowView.CurrentValue++;
                await Task.Delay(1000);
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
