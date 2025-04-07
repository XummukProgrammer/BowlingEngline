using System.Collections.Generic;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Trigger.Models
{
    [System.Serializable]
    public class BETriggerHandlerStepsModel
    {
        [SerializeField]
        private BETriggerHandlerStepModel[] _steps;

        public IEnumerable<BETriggerHandlerStepModel> Steps => _steps;

        public BETriggerHandlerStepModel GetStep(int index)
        {
            if (index >= 0 && index < _steps.Length)
            {
                return _steps[index];
            }
            return null;
        }
    }
}
