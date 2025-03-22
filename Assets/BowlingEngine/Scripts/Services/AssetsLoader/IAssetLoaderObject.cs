using System.Threading.Tasks;

namespace BowlingEngine.Services.AssetsLoader
{
    public interface IAssetLoaderObject
    {
        public Task Load(string path);
        public Task Unload();
    }
}
