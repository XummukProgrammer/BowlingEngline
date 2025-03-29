using UGT.Common.Factories;
using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Common.Gameplay.UI.HUD;
using UGT.Services.Resources;
using Zenject;

namespace UGT.Gameplay.Meta.Installers
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

            Container.BindInterfacesAndSelfTo<GameplayChangerHudService>().AsSingle().NonLazy();
        }

        private void InstallStatesMachine()
        {
            Container.Bind<UGTGameplayBoostrapState>().AsSingle();
            Container.Bind<UGTGameplayLoadState>().AsSingle();
            Container.Bind<UGTGameplayInProgressState>().AsSingle();
            Container.Bind<UGTGameplayUnloadState>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTGameplayStatesMachineService>().AsSingle();
        }
    }
}
