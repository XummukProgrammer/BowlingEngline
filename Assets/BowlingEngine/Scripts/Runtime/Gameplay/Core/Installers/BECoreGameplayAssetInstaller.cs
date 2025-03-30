using BowlingEngine.Gameplay.Core.Models;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    [CreateAssetMenu(fileName = "Core Gameplay Asset", menuName = "Bowling Engine/Assets/Core Gameplay")]
    public class BECoreGameplayAssetInstaller : ScriptableObjectInstaller<BECoreGameplayAssetInstaller>
    {
        [SerializeField]
        private BECoreGameplayModel _model;

        public override void InstallBindings()
        {
            Container.BindInstance(_model);
        }
    }
}
