using BowlingEngine.StaticData.AssetsLoader;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingEngine.Services.AssetsLoader
{
    public class AssetsLoaderService
    {
        public event System.Action<int> PackageStartedLoading;
        public event System.Action PackageFinishedLoading;

        public event System.Action<int> PackageUploadedResource;

        private Dictionary<string, IAssetLoaderObject> _objects = new();

        public bool Has(string id) => _objects.ContainsKey(id);
        public IAssetLoaderObject Get(string id)
        {
            if (_objects.TryGetValue(id, out var @object))
                return @object;
            return null;
        }

        public async Task Load(string id, string path, AssetLoaderObjectType type)
        {
            if (!Has(id))
            {
                var @object = AssetLoaderObjectFactory.Build(type);
                await @object.Load(path);
                _objects[id] = @object;
            }
        }

        public async Task LoadPackage(AssetsLoaderPackageStaticData packageStaticData)
        {
            PackageStartedLoading?.Invoke(packageStaticData.Elements.Count());

            int index = 0;
            foreach (var element in packageStaticData.Elements)
            {
                await Load(element.name, element.Path, element.Type);
                PackageUploadedResource?.Invoke(index);
                index++;
                await Task.Delay(1000);
            }

            PackageFinishedLoading?.Invoke();
        }

        public async Task Unload(string id)
        {
            if (_objects.TryGetValue(id, out var @object))
            {
                await @object.Unload();
                _objects.Remove(id);
            }
        }

        public async Task UnloadPackage(AssetsLoaderPackageStaticData packageStaticData)
        {
            foreach (var element in packageStaticData.Elements)
                await Unload(element.name);
        }
    }
}
