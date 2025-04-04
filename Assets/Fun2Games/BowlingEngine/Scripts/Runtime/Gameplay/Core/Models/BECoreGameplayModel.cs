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
        private float _delayAfterStep = 5;

        [SerializeField]
        private GameObject _pinPrefab;

        [SerializeField]
        private BEPartyModel[] _parties;

        [SerializeField]
        private BEPinModel[] _pins;

        [SerializeField]
        private BEBallModel[] _balls;

        [SerializeField]
        private string _defaultBallID;

        public float DelayAfterStep => _delayAfterStep;
        public GameObject PinPrefab => _pinPrefab;
        public IEnumerable<BEPinModel> Pins => _pins;
        public IEnumerable<BEBallModel> Balls => _balls;
        public IEnumerable<BEPartyModel> Parties => _parties;
        public string DefaultBallID => _defaultBallID;

        public BEPinModel GetPin(string id)
        {
            return _pins.FirstOrDefault(p => p.ID == id);
        }

        public BEBallModel GetBall(string id)
        {
            return _balls.FirstOrDefault(p => p.ID == id);
        }

        public BEBallModel GetBall(int id)
        {
            if (id >= 0 && id < _balls.Length)
            {
                return _balls[id];
            }
            return null;
        }

        public int GetBallID(string id)
        {
            for (int i = 0; i < _balls.Length; i++)
            {
                if (_balls[i].ID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public BEPartyModel GetParty(string id)
        {
            return _parties.FirstOrDefault(p => p.ID == id);
        }
    }
}
