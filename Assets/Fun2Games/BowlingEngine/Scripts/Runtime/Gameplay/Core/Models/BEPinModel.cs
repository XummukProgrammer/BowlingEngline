using BowlingEngine.Gameplay.Core.ScriptableObjects;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEPinModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private BEPinClassSO _class;
        

        public string ID => _id;
        public BEPinClassSO Class => _class;
    }
}
