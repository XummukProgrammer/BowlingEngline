using UnityGameTemplate.Resources.Models;
using UnityGameTemplate.Resources.Services;

namespace UnityGameTemplate.Gameplay.Services
{
    public class UGTGameplayResourcesLoaderService : UGTResourcesLoaderService
    {
        public UGTGameplayResourcesLoaderService(
            UGTResourcesService resourcesService, 
            UGTResourcesModel resourcesModel) 
            : base(resourcesService, 
                  resourcesModel)
        {
        }
    }
}
