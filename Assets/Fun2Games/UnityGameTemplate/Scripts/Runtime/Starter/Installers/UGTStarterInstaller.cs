using UnityGameTemplate.Camera.Services;
using UnityGameTemplate.Localizations.Services;
using UnityGameTemplate.Resources.Factories;
using UnityGameTemplate.Resources.Services;
using UnityGameTemplate.Sounds.Services;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.Starter.States;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.UI.HUD.Services;
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
            InstallObjects();
            InstallUI();
            InstallLocalizations();
            InstallSounds();
        }

        private void InstallFactories()
        {
            Container.Bind<UGTStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<UGTResourcesFactory>().AsSingle();
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

            Container.BindInterfacesAndSelfTo<UGTStarterStatesService>().AsSingle();
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

        private void InstallObjects()
        {
            Container.BindInterfacesAndSelfTo<UGTCameraService>().AsSingle();
        }

        private void InstallUI()
        {
            InstallWindows();
            InstallHUD();
        }

        private void InstallWindows()
        {
            Container.BindInterfacesAndSelfTo<UGTWindowContainerService>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTLoadWindowService>().AsSingle();
        }

        private void InstallHUD()
        {
            Container.BindInterfacesAndSelfTo<UGTHUDContainerService>().AsSingle();
        }

        private void InstallLocalizations()
        {
            Container.Bind<UGTLocalizationsService>().AsSingle();
        }

        private void InstallSounds()
        {
            Container.BindInterfacesAndSelfTo<UGTSoundsService>().AsSingle();
        }
    }
}
