using UnityEngine;
using UnityGameTemplate.Gameplay.Models;
using UnityGameTemplate.Resources.Models;

namespace UnityGameTemplate.Starter.Models
{
    [System.Serializable]
    public class UGTGameplaySceneModel
    {
        [SerializeField]
        private UGTResourceModel _coreSceneResource;

        [SerializeField]
        private UGTResourceModel _metaSceneResource;

        [SerializeField]
        private UGTGameplayType _defaultGameplayType;

        public UGTResourceModel CoreSceneResource => _coreSceneResource;
        public UGTResourceModel MetaSceneResource => _metaSceneResource;
        public UGTGameplayType DefaultGameplayType => _defaultGameplayType;

        public UGTResourceModel GetSceneResource(UGTGameplayType gameplayType)
        {
            switch (gameplayType)
            {
                case UGTGameplayType.Meta:
                    return _metaSceneResource;
                case UGTGameplayType.Core:
                    return _coreSceneResource;
                default:
                    break;
            }
            return null;
        }
    }
}
