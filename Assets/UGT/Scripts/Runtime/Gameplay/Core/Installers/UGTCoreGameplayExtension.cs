using UGT.Common.Factories;
using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Common.Gameplay.UI.HUD;
using UGT.Services.Resources;
using Zenject;

namespace UGT.Gameplay.Core.Installers
{
    public static class UGTCoreGameplayExtension
    {
        public static void InstallCore(this DiContainer diContainer)
        {
            InstallFactories(diContainer);
            InstallServices(diContainer);
        }

        public static void InstallCoreStatesMachine(this DiContainer diContainer)
        {
            diContainer.Bind<UGTGameplayBoostrapState>().AsSingle();
            diContainer.Bind<UGTGameplayLoadState>().AsSingle();
            diContainer.Bind<UGTGameplayInProgressState>().AsSingle();
            diContainer.Bind<UGTGameplayUnloadState>().AsSingle();

            diContainer.BindInterfacesAndSelfTo<UGTGameplayStatesMachineService>().AsSingle();
        }

        private static void InstallFactories(DiContainer diContainer)
        {
            diContainer.Bind<UGTStateFactory>().AsSingle();
        }

        private static void InstallServices(DiContainer diContainer)
        {
            diContainer.Bind<UGTResourcesLoaderService>().AsSingle();

            diContainer.BindInterfacesAndSelfTo<GameplayChangerHudService>().AsSingle().NonLazy();
        }
    }
}
