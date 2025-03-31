using UnityEngine;
using UnityGameTemplate.Resources.Models;
using Zenject;

namespace UnityGameTemplate.Resources.Settings
{
    [CreateAssetMenu(fileName = "Resources Settings", menuName = "Unity Game Template/Resources/Settings")]
    public class UGTResourcesSettings : ScriptableObjectInstaller<UGTResourcesSettings>
    {
        [SerializeField]
        private UGTResourcesModel _resourcesModel;

        public override void InstallBindings()
        {
            Container.BindInstances(_resourcesModel);
        }
    }
}
