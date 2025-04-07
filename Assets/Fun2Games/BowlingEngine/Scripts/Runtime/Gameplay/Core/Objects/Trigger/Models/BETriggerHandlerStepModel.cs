using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Trigger.Models
{
    [System.Serializable]
    public class BETriggerHandlerStepModel
    {
        [SerializeField]
        private BETriggerHandlerType _type;

        [SerializeField]
        private bool _boolValue;

        [SerializeField]
        private int _intValue;

        [SerializeField]
        private float _floatValue;

        [SerializeField]
        private string _stringValue;

        public BETriggerHandlerType Type => _type;
        public bool BoolValue => _boolValue;
        public int IntValue => _intValue;
        public float FloatValue => _floatValue;
        public string StringValue => _stringValue;
    }
}
