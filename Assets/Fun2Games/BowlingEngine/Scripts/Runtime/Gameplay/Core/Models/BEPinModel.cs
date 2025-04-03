using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEPinModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private float _mass = 0.6f;

        public string ID => _id;
        public float Mass => _mass;
    }
}
