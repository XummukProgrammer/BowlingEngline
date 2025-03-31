using UnityGameTemplate.Resources.Models;
using UnityGameTemplate.Resources.Services;

namespace BowlingEngine.Gameplay.Core.Services
{
    public class BECoreGameplayResourcesLoaderService : UGTResourcesLoaderService
    {
        public BECoreGameplayResourcesLoaderService(
            UGTResourcesService resourcesService, 
            UGTResourcesModel resourcesModel) 
            : base(resourcesService, 
                  resourcesModel)
        {
        }
    }
}
