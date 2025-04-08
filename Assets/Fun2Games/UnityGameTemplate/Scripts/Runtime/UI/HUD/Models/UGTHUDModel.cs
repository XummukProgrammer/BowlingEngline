using UnityEngine;
using UnityGameTemplate.UI.HUD.Views;

namespace UnityGameTemplate.UI.HUD.Models
{
    public class UGTHUDModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private UGTHUDView _prefab;

        [SerializeField]
        private UGTHUDPlaceType _placeType = UGTHUDPlaceType.TopSideLeft;

        public string ID => _id;
        public UGTHUDView Prefab => _prefab;
        public UGTHUDPlaceType PlaceType => _placeType;
    }
}
