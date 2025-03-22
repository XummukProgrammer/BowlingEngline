using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.StaticData.AssetsLoader;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.AssetsLoader
{
    public abstract class DynamicAssetLoader<T> : MonoBehaviour
    {
        [SerializeField]
        private AssetsLoaderPackageElementStaticData _data;

        private AssetsLoaderService _assetsLoaderService;

        [Inject]
        public void Construct(AssetsLoaderService assetsLoaderService)
        {
            _assetsLoaderService = assetsLoaderService;
        }

        public async Task Load()
        {
            if (_data == null)
                return;

            var @object = _assetsLoaderService.Get(_data.name);
            if (@object != null && @object is AssetLoaderObjectDynamic<T> castedObject)
                await LoadObject(castedObject.Result);
        }

        protected abstract Task LoadObject(T result);
    }
}
