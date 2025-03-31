using UnityGameTemplate.Resources.Implementation;
using UnityGameTemplate.Resources.Interfaces;
using UnityGameTemplate.Resources.Models;

namespace UnityGameTemplate.Resources.Factories
{
    public class UGTResourcesFactory
    {
        public UGTIResource Create(UGTResourceModel resourceModel)
        {
            switch (resourceModel.Type)
            {
                case UGTResourceType.Scene:
                    return new UGTSceneResource(resourceModel.ID, resourceModel.Path);
            }
            return null;
        }
    }
}
