using BowlingEngine.Gameplay.AssetsLoader;
using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.ObjectsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;
using BowlingEngine.StaticData.Gameplay;
using BowlingEngine.UI.Windows.Load;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.CommonStates
{
    public abstract class CommonStatesMachineLoadGameplayState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private LoadWindowView _loadWindowView;

        private readonly AssetsLoaderService _assetsLoaderService;
        private readonly GameplayContainerStaticData _gameplayContainerStaticData;
        private readonly ObjectsLoaderService _objectsLoaderService;

        public CommonStatesMachineLoadGameplayState(
            AssetsLoaderService assetsLoaderService,
            GameplayContainerStaticData gameplayContainerStaticData,
            ObjectsLoaderService objectsLoaderService)
        {
            _assetsLoaderService = assetsLoaderService;
            _gameplayContainerStaticData = gameplayContainerStaticData;
            _objectsLoaderService = objectsLoaderService;
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
            await LoadObjects();

            _loadWindowView.IsEnabled = false;
        }

        private async Task LoadPackage()
        {
            var gameplayType = GetGameplayType();
            var gameplayData = _gameplayContainerStaticData.Get(gameplayType);

            if (gameplayData != null)
                await _assetsLoaderService.LoadPackage(gameplayData.Package);
        }

        private async Task LoadObjects()
        {
            var prefabObjects = Resources.FindObjectsOfTypeAll<PrefabAssetLoader>();
            var objects = new List<ObjectsLoaderElement>();

            foreach (var prefabObject in prefabObjects)
            {
                await prefabObject.Load();

                objects.Add(new(
                    prefabObject.Prefab, 
                    prefabObject.Placeholder, 
                    prefabObject.Position, 
                    prefabObject.Rotation));
            }

            await _objectsLoaderService.LoadElements(objects);
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
