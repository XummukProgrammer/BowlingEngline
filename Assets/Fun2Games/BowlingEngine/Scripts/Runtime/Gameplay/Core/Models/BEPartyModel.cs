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
        private BEScenePinModel[] _pins;

        public string ID => _id;
        public IEnumerable<BEScenePinModel> Pins => _pins;
    }
}
