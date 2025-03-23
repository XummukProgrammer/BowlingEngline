using BowlingEngine.Infrastructure.Factories;
using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.ObjectsLoader;
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
            Container.BindInterfacesAndSelfTo<ObjectsLoaderService>().AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }
    }
}
