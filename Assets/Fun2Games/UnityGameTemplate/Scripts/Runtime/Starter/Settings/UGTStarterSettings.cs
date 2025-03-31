using UnityEngine;
using UnityGameTemplate.Starter.Models;
using Zenject;

namespace UnityGameTemplate.Starter.Settings
{
    [CreateAssetMenu(fileName = "Starter Settings", menuName = "Unity Game Template/Starter/Settings")]
    public class UGTStarterSettings : ScriptableObjectInstaller<UGTStarterSettings>
    {
        [SerializeField]
        private UGTProjectModel _projectModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_projectModel);
        }
    }
}
