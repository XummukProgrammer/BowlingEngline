using UnityGameTemplate.Camera.Services;
using UnityGameTemplate.Resources.Factories;
using UnityGameTemplate.Resources.Services;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.Starter.States;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.UI.Windows.Common.LoadWindow;
using UnityGameTemplate.UI.Windows.Services;
using Zenject;

namespace UnityGameTemplate.Starter.Installers
{
    public class UGTStarterInstaller : MonoInstaller<UGTStarterInstaller>
    {
        public override void InstallBindings()
        {
            InstallFactories();
            InstallResources();
            InstallStates();
            InstallData();

            Container.BindInterfacesAndSelfTo<UGTCameraService>().AsSingle();

            InstallUI();
        }

        private void InstallFactories()
        {
            Container.Bind<UGTStateFactory>().AsSingle();
            Container.Bind<UGTResourcesFactory>().AsSingle();
        }

        private void InstallStates()
        {
            Container.Bind<UGTStarterStatesBoostrap>().AsSingle();
            Container.Bind<UGTStarterStatesLoad>().AsSingle();
            Container.Bind<UGTStarterStatesGameplayLoad>().AsSingle();
            Container.Bind<UGTStarterStatesGameplayInProgress>().AsSingle();
            Container.Bind<UGTStarterStatesGameplayUnload>().AsSingle();
            Container.Bind<UGTStarterStatesGameplayChange>().AsSingle();
            Container.Bind<UGTStarterStatesUnload>().AsSingle();
            Container.Bind<UGTStarterStatesDisable>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTStarterStatesService>().AsSingle().NonLazy();
        }

        private void InstallResources()
        {
            Container.Bind<UGTResourcesService>().AsSingle();
            Container.Bind<UGTStarterResourcesLoaderService>().AsSingle();
        }

        private void InstallData()
        {
            Container.Bind<UGTGameplayData>().AsSingle();
        }

        private void InstallUI()
        {
            InstallWindows();
        }

        private void InstallWindows()
        {
            Container.BindInterfacesAndSelfTo<UGTWindowContainerService>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTLoadWindowService>().AsSingle();
        }
    }
}
