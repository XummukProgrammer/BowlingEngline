using UGT.Basic.Data;
using UGT.Common.Factories;
using UGT.Services.Localizations;
using UGT.Services.Resources;
using UGT.Services.UI.HUD;
using Zenject;

namespace UGT.Infrastructure.Installers
{
    public class UGTInfrastructureInstaller : MonoInstaller<UGTInfrastructureInstaller>
    {
        public override void InstallBindings()
        {
            InstallFactories();
            InstallServices();
            InstallData();
        }

        private void InstallFactories()
        {
            Container.Bind<UGTStateFactory>().AsSingle();
        }

        private void InstallServices()
        {
            Container.Bind<UGTResourcesService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UGTHudContainerService>().AsSingle();
            Container.Bind<UGTLocalizationsService>().AsSingle();
        }

        private void InstallData()
        {
            Container.Bind<UGTBasicData>().AsSingle();
        }
    }
}
