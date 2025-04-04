using UnityEngine;

namespace BowlingEngine.Gameplay.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Pin Class", menuName = "Bowling Engine/Pin Class")]
    public class BEPinClassSO : ScriptableObject
    {
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

        [SerializeField]
        private float _upForceForPin = 0.1f;

        [SerializeField]
        private float _dirForceForPin = 0.6f;

        public float Mass => _mass;
        public int Health => _health;
        public float Bounce => _bounce;
        public int DamageForBall => _damageForBall;
        public int DamageForPin => _damageForPin;
        public float UpForceForPin => _upForceForPin;
        public float DirForceForPin => _dirForceForPin;
    }
}
