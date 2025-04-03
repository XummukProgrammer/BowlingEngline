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
        private float _delayAfterStep = 5;

        [SerializeField]
        private GameObject _pinPrefab;

        [SerializeField]
        private BEPartyModel[] _parties;

        [SerializeField]
        private BEPinModel[] _pins;

        [SerializeField]
        private BEBallModel[] _balls;

        public int MaxFrames => _maxFrames;
        public int MaxSteps => _maxSteps;
        public float DelayAfterStep => _delayAfterStep;
        public GameObject PinPrefab => _pinPrefab;
        public IEnumerable<BEPinModel> Pins => _pins;
        public IEnumerable<BEBallModel> Balls => _balls;
        public IEnumerable<BEPartyModel> Parties => _parties;

        public BEPinModel GetPin(string id)
        {
            return _pins.FirstOrDefault(p => p.ID == id);
        }

        public BEBallModel GetBall(string id)
        {
            return _balls.FirstOrDefault(p => p.ID == id);
        }

        public BEPartyModel GetParty(string id)
        {
            return _parties.FirstOrDefault(p => p.ID == id);
        }
    }
}
