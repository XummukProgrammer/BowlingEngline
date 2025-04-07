using System.Collections.Generic;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Trigger.Models
{
    [System.Serializable]
    public class BETriggerHandlerStepModel
    {
        [SerializeField]
        private BETriggerHandlerStepActionModel[] _actions;

        public IEnumerable<BETriggerHandlerStepActionModel> Actions => _actions;
    }
}
