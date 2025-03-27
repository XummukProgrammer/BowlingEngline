using UGT.Common.Gameplay;
using UGT.Services.Resources.Models;
using UnityEngine;

namespace UGT.Basic.Models
{
    [System.Serializable]
    public class UGTBasicModel
    {
        [SerializeField]
        private UGTResourcesModel _metaResources;

        [SerializeField]
        private UGTResourcesModel _coreResources;

        [SerializeField]
        private UGTGameplayType _defaultGameplayType;

        public UGTResourcesModel MetaResources => _metaResources;
        public UGTResourcesModel CoreResources => _coreResources;
        public UGTGameplayType DefaultGameplayType => _defaultGameplayType;

        public UGTResourcesModel DefaultResources
        {
            get
            {
                switch (_defaultGameplayType)
                {
                    case UGTGameplayType.Meta:
                        return _metaResources;
                    case UGTGameplayType.Core:
                        return _coreResources;
                    default:
                        break;
                }
                return null;
            }
        }
    }
}
