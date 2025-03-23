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
        private readonly CommonStatesMachineService _commonStatesMachineService;

        public CommonStatesMachineLoadGameplayState(
            AssetsLoaderService assetsLoaderService,
            GameplayContainerStaticData gameplayContainerStaticData,
            ObjectsLoaderService objectsLoaderService,
            CommonStatesMachineService commonStatesMachineService)
        {
            _assetsLoaderService = assetsLoaderService;
            _gameplayContainerStaticData = gameplayContainerStaticData;
            _objectsLoaderService = objectsLoaderService;
            _commonStatesMachineService = commonStatesMachineService;
        }

        public void Enter()
        {
            _loadWindowView = GameObject.FindFirstObjectByType<LoadWindowView>(FindObjectsInactive.Include);

            _ = Load();
        }

        public void Exit()
        {
        }

        private async Task Load()
        {
            _loadWindowView.IsEnabled = true;

            await LoadPackage();
            await LoadObjects();

            _loadWindowView.IsEnabled = false;

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

        protected abstract GameplayTypeStaticData GetGameplayType();
    }
}
