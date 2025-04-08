using System.Linq;
using UnityEngine;
using UnityGameTemplate.UI.HUD.Models;

namespace UnityGameTemplate.UI.HUD.Views
{
    public class UGTHUDContainerView : MonoBehaviour
    {
        [SerializeField]
        private UGTHUDContainerPlaceModel[] _places;

        public UGTHUDView CreateView(UGTHUDView prefab, UGTHUDPlaceType placeType)
        {
            var place = _places.FirstOrDefault(p => p.Type == placeType);
            if (place != null)
            {
                return Instantiate(prefab, place.Transform);
            }
            return null;
        }
    }
}
