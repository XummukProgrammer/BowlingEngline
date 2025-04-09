using UnityEngine;

namespace UnityGameTemplate.UI.HUD.Common.Message
{
    [System.Serializable]
    public class UGTMessageHUDPlaceTextModel
    {
        [SerializeField]
        private UGTMessageHUDPlaceType _placeType;

        [SerializeField]
        private TMPro.TMP_Text _text;

        public UGTMessageHUDPlaceType PlaceType => _placeType;
        public TMPro.TMP_Text Text => _text;
    }
}
