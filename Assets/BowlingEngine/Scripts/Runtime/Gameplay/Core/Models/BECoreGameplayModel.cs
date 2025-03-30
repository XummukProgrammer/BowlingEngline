using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BECoreGameplayModel
    {
        [SerializeField]
        private GameObject _pinPrefab;

        public GameObject PinPrefab => _pinPrefab;
    }
}
