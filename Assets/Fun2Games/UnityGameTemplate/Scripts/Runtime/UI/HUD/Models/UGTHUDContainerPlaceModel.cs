using UnityEngine;

namespace UnityGameTemplate.UI.HUD.Models
{
    [System.Serializable]
    public class UGTHUDContainerPlaceModel
    {
        [SerializeField]
        private UGTHUDPlaceType _type;

        [SerializeField]
        private Transform _transform;

        public UGTHUDPlaceType Type => _type;
        public Transform Transform => _transform;
    }
}
