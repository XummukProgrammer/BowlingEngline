using UGT.Infrastructure.Factories;
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
            Container.BindInterfacesAndSelfTo<UGTStateFactory>().AsSingle();
        }

        private void InstallServices()
        {
        }
    }
}
