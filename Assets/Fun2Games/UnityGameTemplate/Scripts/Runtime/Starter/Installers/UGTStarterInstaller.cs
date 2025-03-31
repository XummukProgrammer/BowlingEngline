using UnityGameTemplate.Starter.Services;
using Zenject;

namespace UnityGameTemplate.Starter.Installers
{
    public class UGTStarterInstaller : MonoInstaller<UGTStarterInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UGTStarterService>().AsSingle().NonLazy();
        }
    }
}
