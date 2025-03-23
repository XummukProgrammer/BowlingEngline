using BowlingEngine.StaticData.AssetsLoader;
using BowlingEngine.StaticData.Gameplay;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "Static Data Installer", menuName = "Bowling Engine/Installers/Static Data")]
    public class StaticDataInstaller : ScriptableObjectInstaller<StaticDataInstaller>
    {
        [SerializeField]
        private GameplayContainerStaticData _gameplayContainer;

        [SerializeField]
        private AssetsLoaderPackageStaticData _package;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameplayContainer);
            Container.BindInstance(_package);
        }
    }
}
