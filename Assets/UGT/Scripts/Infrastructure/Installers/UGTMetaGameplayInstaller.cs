using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Infrastructure.Factories;
using UGT.Services.Resources;
using Zenject;

namespace UGT.Infrastructure.Installers
{
    public class UGTMetaGameplayInstaller : MonoInstaller<UGTMetaGameplayInstaller>
    {
        public override void InstallBindings()
        {
            InstallFactories();
            InstallServices();
        }

        private void InstallFactories()
        {
            Container.Bind<UGTStateFactory>().AsSingle();
        }

        private void InstallServices()
        {
            InstallStatesMachine();

            Container.Bind<UGTResourcesLoaderService>().AsSingle();
        }

        private void InstallStatesMachine()
        {
            Container.Bind<UGTGameplayBoostrapState>().AsSingle();
            Container.Bind<UGTGameplayLoadState>().AsSingle();
            Container.Bind<UGTGameplayUnloadState>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTGameplayStatesMachineService>().AsSingle();
        }
    }
}
