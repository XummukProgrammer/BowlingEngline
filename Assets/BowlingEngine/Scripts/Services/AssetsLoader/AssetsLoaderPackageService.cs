using System.Threading.Tasks;

namespace BowlingEngine.Services.AssetsLoader
{
    public class AssetsLoaderPackageService
    {
        private readonly AssetsLoaderPackageStaticData _packageStaticData;
        private readonly AssetsLoaderService _assetLoaderService;

        public AssetsLoaderPackageService(
            AssetsLoaderPackageStaticData packageStaticData, 
            AssetsLoaderService assetsLoaderService)
        {
            _packageStaticData = packageStaticData;
            _assetLoaderService = assetsLoaderService;
        }

        public async Task Load()
        {
            foreach (var element in _packageStaticData.Elements)
                await _assetLoaderService.Load(element.name, element.Path, element.Type);
        }

        public async Task Unload()
        {
            foreach (var element in _packageStaticData.Elements)
                await _assetLoaderService.Unload(element.name);
        }
    }
}
