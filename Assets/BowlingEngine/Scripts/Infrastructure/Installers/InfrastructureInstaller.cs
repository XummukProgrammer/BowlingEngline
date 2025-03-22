using BowlingEngine.Services.AssetsLoader;
using Zenject;

namespace BowlingEngine.Infrastructure.Installers
{
    public class InfrastructureInstaller : MonoInstaller<InfrastructureInstaller>
    {
        public override void InstallBindings()
        {
            InstallServices();
            InstallFactories();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<AssetsLoaderService>().AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
        }
    }
}
