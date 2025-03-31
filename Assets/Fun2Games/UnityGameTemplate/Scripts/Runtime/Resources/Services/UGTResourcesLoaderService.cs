using System.Threading.Tasks;
using UnityGameTemplate.Resources.Models;

namespace UnityGameTemplate.Resources.Services
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
