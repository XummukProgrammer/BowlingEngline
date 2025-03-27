using UGT.Services.Resources.Models;
using UnityEngine;
using Zenject;

namespace UGT.Services.Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Resources Asset", menuName = "UGT/Assets/Resources/Resources", order = 1)]
    public class UGTResourcesAssetInstaller : ScriptableObjectInstaller<UGTResourcesAssetInstaller>
    {
        [SerializeField]
        private UGTResourcesModel _resourcesModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_resourcesModel);
        }
    }
}
