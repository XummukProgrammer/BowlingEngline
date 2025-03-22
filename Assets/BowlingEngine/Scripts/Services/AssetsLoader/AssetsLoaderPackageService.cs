using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Services.AssetsLoader
{
    public class AssetsLoaderPackageService : MonoBehaviour
    {
        [SerializeField]
        private AssetsLoaderPackageData[] _objects;

        private AssetsLoaderService _assetsLoaderService;

        [Inject]
        public void Construct(AssetsLoaderService assetsLoaderService)
        {
            _assetsLoaderService = assetsLoaderService;
        }

        public async Task Load()
        {
            foreach (var @object in _objects)
                await _assetsLoaderService.Load(@object.Id, @object.Path, @object.Type);
        }

        public async Task Unload()
        {
            foreach (var @object in _objects)
                await _assetsLoaderService.Unload(@object.Id);
        }

        private void Start()
        {
            _ = Load();
        }

        private void OnDestroy()
        {
            _ = Unload();
        }
    }
}
