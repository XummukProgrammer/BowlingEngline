using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.Starter.States;
using UnityGameTemplate.States.Factories;
using Zenject;

namespace UnityGameTemplate.Starter.Installers
{
    public class UGTStarterInstaller : MonoInstaller<UGTStarterInstaller>
    {
        public override void InstallBindings()
        {
            InstallFactories();
            InstallStates();
        }

        private void InstallFactories()
        {
            Container.Bind<UGTStateFactory>().AsSingle();
        }

        private void InstallStates()
        {
            Container.Bind<UGTStarterStatesBoostrap>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTStarterStatesService>().AsSingle().NonLazy();
        }
    }
}
