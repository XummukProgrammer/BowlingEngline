using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Trigger.Models
{
    [System.Serializable]
    public class BETriggerHandlerStepActionModel
    {
        [SerializeField]
        private BETriggerHandlerStepActionType _type;

        [SerializeField]
        private bool _boolValue;

        [SerializeField]
        private int _intValue;

        [SerializeField]
        private float _floatValue;

        [SerializeField]
        private string _stringValue;

        [SerializeField]
        private Vector3 _vector3Value;

        public BETriggerHandlerStepActionType Type => _type;
        public bool BoolValue => _boolValue;
        public int IntValue => _intValue;
        public float FloatValue => _floatValue;
        public string StringValue => _stringValue;
        public Vector3 Vector3Value => _vector3Value;
    }
}
