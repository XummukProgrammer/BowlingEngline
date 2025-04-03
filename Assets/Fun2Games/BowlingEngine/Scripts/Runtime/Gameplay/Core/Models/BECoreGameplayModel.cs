using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGameTemplate.Gameplay.Models;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BECoreGameplayModel : UGTGameplayModel
    {
        [SerializeField]
        private int _maxFrames = 10;

        [SerializeField]
        private int _maxSteps = 2;

        [SerializeField]
        private GameObject _pinPrefab;

        [SerializeField]
        private BEPinModel[] _pins;

        public int MaxFrames => _maxFrames;
        public int MaxSteps => _maxSteps;
        public GameObject PinPrefab => _pinPrefab;
        public IEnumerable<BEPinModel> Pins => _pins;

        public BEPinModel GetPin(string id)
        {
            return _pins.FirstOrDefault(p => p.ID == id);
        }
    }
}
