using UnityEngine;
using Zenject;

namespace UGT.Common.Gameplay.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Gameplay Asset", menuName = "UGT/Assets/Gameplay/Asset")]
    public class UGTGameplayAssetInstaller : ScriptableObjectInstaller<UGTGameplayAssetInstaller>
    {
        [SerializeField]
        private UGTGameplayType _type;

        public override void InstallBindings()
        {
            Container.BindInstance(_type);
        }
    }
}
