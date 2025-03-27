using UGT.Basic.Models;
using UnityEngine;
using Zenject;

namespace UGT.Basic.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Basic Asset", menuName = "UGT/Assets/Basic/Asset")]
    public class UGTBasicAssetInstaller : ScriptableObjectInstaller<UGTBasicAssetInstaller>
    {
        [SerializeField]
        private UGTBasicModel _basicModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_basicModel);
        }
    }
}
