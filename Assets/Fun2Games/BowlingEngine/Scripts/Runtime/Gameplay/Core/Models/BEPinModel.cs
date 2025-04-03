using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Models
{
    [System.Serializable]
    public class BEPinModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private float _mass = 0.6f;

        [SerializeField]
        private int _health = 4;

        [SerializeField]
        private float _bounce = 0.6f;

        [SerializeField]
        private int _damageForBall = 1;

        [SerializeField]
        private int _damageForPin = 1;

        public string ID => _id;
        public float Mass => _mass;
        public int Health => _health;
        public float Bounce => _bounce;
        public int DamageForBall => _damageForBall;
        public int DamageForPin => _damageForPin;
    }
}
