using System.Threading.Tasks;
using UGT.Services.Resources.Models;

namespace UGT.Services.Resources
{
    public class UGTResourcesLoaderService
    {
        private readonly UGTResourcesService _resourcesService;
        private readonly UGTResourcesModel _resourcesModel;

        public UGTResourcesLoaderService(
            UGTResourcesService resourcesService, 
            UGTResourcesModel resourcesModel)
        {
            _resourcesService = resourcesService;
            _resourcesModel = resourcesModel;
        }

        public async Task Load()
        {
            await _resourcesService.Load(_resourcesModel);
        }

        public async Task Unload()
        {
            await _resourcesService.Unload(_resourcesModel);
        }
    }
}
