using UnityGameTemplate.Resources.Models;
using UnityGameTemplate.Resources.Services;

namespace UnityGameTemplate.Starter.Services
{
    public class UGTStarterResourcesLoaderService : UGTResourcesLoaderService
    {
        public UGTStarterResourcesLoaderService(
            UGTResourcesService resourcesService, 
            UGTResourcesModel resourcesModel) 
            : base(resourcesService, 
                  resourcesModel)
        {
        }
    }
}
