using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingEngine.Services.AssetsLoader
{
    public class AssetsLoaderService
    {
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

        public async Task Unload(string id)
        {
            if (_objects.TryGetValue(id, out var @object))
            {
                await @object.Unload();
                _objects.Remove(id);
            }
        }
    }
}
