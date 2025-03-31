using UnityGameTemplate.Gameplay.Services;
using UnityGameTemplate.Gameplay.Signals;
using UnityGameTemplate.Gameplay.States;
using UnityGameTemplate.States.Factories;
using Zenject;

namespace UnityGameTemplate.Gameplay.Installers
{
    public class UGTGameplayInstaller : MonoInstaller<UGTGameplayInstaller>
    {
        public override void InstallBindings()
        {
            InstallFactories();
            InstallStates();
            InstallSignalBus();

            Container.Bind<UGTGameplayResourcesLoaderService>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<UGTStateFactory>().AsSingle();
        }

        private void InstallStates()
        {
            Container.Bind<UGTGameplayStatesBoostrap>().AsSingle();
            Container.Bind<UGTGameplayStatesLoad>().AsSingle();
            Container.Bind<UGTGameplayStatesInProgress>().AsSingle();
            Container.Bind<UGTGameplayStatesUnload>().AsSingle();
            Container.Bind<UGTGameplayStatesDisable>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTGameplayStatesService>().AsSingle();
        }

        private void InstallSignalBus()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<UGTGameplayDisableSignal>();
            Container.DeclareSignal<UGTGameplayChangeSignal>();
        }
    }
}
