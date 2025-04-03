using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEBallModel
    {
        [SerializeField]
        private string _id;

        public string ID => _id;
    }
}
