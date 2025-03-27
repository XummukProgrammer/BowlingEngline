using UGT.Infrastructure.Factories;
using UGT.Services.Resources;
using Zenject;

namespace UGT.Infrastructure.Installers
{
    public class UGTInfrastructureInstaller : MonoInstaller<UGTInfrastructureInstaller>
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
            Container.Bind<UGTResourcesService>().AsSingle();
            Container.Bind<UGTResourcesLoaderService>().AsSingle();
        }
    }
}
