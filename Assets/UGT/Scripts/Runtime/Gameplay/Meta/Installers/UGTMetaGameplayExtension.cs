using UGT.Common.Factories;
using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Common.Gameplay.UI.HUD;
using UGT.Services.Resources;
using Zenject;

namespace UGT.Gameplay.Meta.Installers
{
    public static class UGTMetaGameplayExtension
    {
        public static void InstallMeta(this DiContainer diContainer)
        {
            InstallFactories(diContainer);
            InstallServices(diContainer);
        }

        private static void InstallFactories(DiContainer diContainer)
        {
            diContainer.Bind<UGTStateFactory>().AsSingle();
        }

        private static void InstallServices(DiContainer diContainer)
        {
            InstallStatesMachine(diContainer);

            diContainer.Bind<UGTResourcesLoaderService>().AsSingle();

            diContainer.BindInterfacesAndSelfTo<GameplayChangerHudService>().AsSingle().NonLazy();
        }

        private static void InstallStatesMachine(DiContainer diContainer)
        {
            diContainer.Bind<UGTGameplayBoostrapState>().AsSingle();
            diContainer.Bind<UGTGameplayLoadState>().AsSingle();
            diContainer.Bind<UGTGameplayInProgressState>().AsSingle();
            diContainer.Bind<UGTGameplayUnloadState>().AsSingle();

            diContainer.BindInterfacesAndSelfTo<UGTGameplayStatesMachineService>().AsSingle();
        }
    }
}
