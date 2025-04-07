using BowlingEngine.Gameplay.Core.Objects.Trigger.Models;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Trigger.Settings
{
    [CreateAssetMenu(fileName = "Trigger Handler Settings", menuName = "Bowling Engine/Trigger/Settings")]
    public class BETriggerHandlerSettings : ScriptableObjectInstaller<BETriggerHandlerSettings>
    {
        [SerializeField]
        private BETriggerHandlerStepsModel _stepsModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_stepsModel);
        }
    }
}
