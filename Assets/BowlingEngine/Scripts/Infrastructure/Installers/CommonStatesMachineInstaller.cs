using BowlingEngine.CommonStates;
using Zenject;

namespace BowlingEngine.Infrastructure.Installers
{
    public class CommonStatesMachineInstaller : MonoInstaller<CommonStatesMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CommonStatesMachineBoostrapState>().AsSingle();

            Container.BindInterfacesAndSelfTo<CommonStatesMachineService>().AsSingle().NonLazy();
        }
    }
}
