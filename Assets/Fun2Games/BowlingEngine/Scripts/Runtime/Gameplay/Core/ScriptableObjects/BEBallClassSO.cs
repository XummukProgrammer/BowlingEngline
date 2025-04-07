using BowlingEngine.Gameplay.Core.Objects.Trigger.Models;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Ball Class", menuName = "Bowling Engine/Ball Class")]
    public class BEBallClassSO : ScriptableObject
    {
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
        private BETriggerHandlerStepsModel _stepsModel;

        public int Health => _health;
        public float Speed => _speed;
        public float UpForceForPin => _upForceForPin;
        public float ForwardForceForPin => _forwardForceForPin;
        public float DirForceForPin => _dirForceForPin;
        public BETriggerHandlerStepsModel StepsModel => _stepsModel;
    }
}
