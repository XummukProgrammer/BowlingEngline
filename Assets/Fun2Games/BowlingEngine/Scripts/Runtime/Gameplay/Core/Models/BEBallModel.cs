using BowlingEngine.Gameplay.Core.ScriptableObjects;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEBallModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private string _skinID;

        [SerializeField]
        private BEBallClassSO _class;

        public string ID => _id;
        public string SkinID => _skinID;
        public BEBallClassSO Class => _class;
    }
}
