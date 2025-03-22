using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.StaticData.AssetsLoader;
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

        private void Start()
        {
            if (_data == null)
                return;

            var obj = _assetsLoaderService.Get(_data.name);
            if (obj != null && obj is AssetLoaderObjectDynamic<T> castedObject)
                LoadObject(castedObject.Result);
        }

        protected abstract void LoadObject(T result);
    }
}
