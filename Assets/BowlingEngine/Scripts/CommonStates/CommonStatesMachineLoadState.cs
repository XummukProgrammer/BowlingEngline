using BowlingEngine.Gameplay.AssetsLoader;
using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.ObjectsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;
using BowlingEngine.StaticData.AssetsLoader;
using BowlingEngine.UI.Windows.Load;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.CommonStates
{
    public abstract class CommonStatesMachineLoadState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private LoadWindowView _loadWindowView;

        private readonly AssetsLoaderService _assetsLoaderService;
        private readonly ObjectsLoaderService _objectsLoaderService;

        public CommonStatesMachineLoadState(
            AssetsLoaderService assetsLoaderService, ObjectsLoaderService objectsLoaderService)
        {
            _assetsLoaderService = assetsLoaderService;
            _objectsLoaderService = objectsLoaderService;
        }

        public void Enter()
        {
            _loadWindowView = GetLoadWindowView();

            _ = Load();
        }

        public void Exit()
        {
        }

        private async Task Load()
        {
            OnLoadStarted();

            await LoadPackage(GetPackageStaticData());
            await LoadObjects();

            OnLoadFinished();
        }

        private async Task LoadPackage(AssetsLoaderPackageStaticData packageStaticData)
        {
            await _assetsLoaderService.LoadPackage(packageStaticData);
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

        protected abstract AssetsLoaderPackageStaticData GetPackageStaticData();

        protected virtual LoadWindowView GetLoadWindowView()
        {
            return GameObject.FindFirstObjectByType<LoadWindowView>();
        }

        protected virtual void OnLoadStarted() 
        {
            if (_loadWindowView != null)
                _loadWindowView.IsEnabled = true;
        }

        protected virtual void OnLoadFinished() 
        {
            if (_loadWindowView != null)
                _loadWindowView.IsEnabled = false;
        }
    }
}
