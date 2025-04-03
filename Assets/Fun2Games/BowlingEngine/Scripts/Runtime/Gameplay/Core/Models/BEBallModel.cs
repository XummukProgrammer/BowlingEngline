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

        [SerializeField]
        private float _upForceForPin = 1;

        [SerializeField]
        private float _forwardForceForPin = 1;

        [SerializeField]
        private float _dirForceForPin = 3;

        [SerializeField]
        private string _skinID;

        public string ID => _id;
        public int Health => _health;
        public float Speed => _speed;
        public float UpForceForPin => _upForceForPin;
        public float ForwardForceForPin => _forwardForceForPin;
        public float DirForceForPin => _dirForceForPin;
        public string SkinID => _skinID;
    }
}
