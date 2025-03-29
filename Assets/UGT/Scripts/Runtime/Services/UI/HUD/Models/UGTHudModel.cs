using UGT.Services.UI.HUD;
using UnityEngine;

namespace UGT.Services.UI.Models
{
    [System.Serializable]
    public class UGTHudModel
    {
        [SerializeField]
        private UGTHudView _prefab;

        [SerializeField]
        private UGTHudLocation _location = UGTHudLocation.TopSideLeft;

        public UGTHudView Prefab => _prefab;
        public UGTHudLocation Location => _location;
    }
}
