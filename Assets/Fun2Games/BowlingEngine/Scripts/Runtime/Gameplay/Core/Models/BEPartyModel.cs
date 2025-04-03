using System.Collections.Generic;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEPartyModel
    {
        [SerializeField]
        private string _id = "Default";

        [SerializeField]
        private int _maxFrames = 10;

        [SerializeField]
        private int _maxSteps = 2;

        [SerializeField]
        private BEScenePinModel[] _pins;

        public string ID => _id;
        public int MaxFrames => _maxFrames;
        public int MaxSteps => _maxSteps;
        public IEnumerable<BEScenePinModel> Pins => _pins;
    }
}
