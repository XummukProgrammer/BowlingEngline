using UGT.Services.UI.HUD;
using UnityEngine;

namespace UGT.Services.UI.Models
{
    [System.Serializable]
    public class UGTHudContainerElementModel
    {
        [SerializeField]
        private UGTHudLocation _location;

        [SerializeField]
        private Transform _transform;

        public UGTHudLocation Location => _location;
        public Transform Transform => _transform;
    }
}
