using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEBallModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private int _health = 3;

        [SerializeField]
        private float _speed = 5;

        public string ID => _id;
        public int Health => _health;
        public float Speed => _speed;
    }
}
