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

        [SerializeField]
        private UGTGameplaySceneModel _gameplaySceneModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_projectModel);
            Container.BindInstance(_gameplaySceneModel);
        }
    }
}
