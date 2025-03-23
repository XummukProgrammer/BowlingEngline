using BowlingEngine.CommonStates;
using Zenject;

namespace BowlingEngine.Infrastructure.Installers
{
    public class CommonStatesMachineInstaller : MonoInstaller<CommonStatesMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<CommonStatesMachineBoostrapState>().AsSingle();
            Container.Bind<CommonStatesMachineDefaultLoadState>().AsSingle();
            Container.Bind<CommonStatesMachineLoadMetaGameplayState>().AsSingle();
            Container.Bind<CommonStatesMachineLoadCoreGameplayState>().AsSingle();
            Container.Bind<CommonStatesMachineMetaGameplayState>().AsSingle();
            Container.Bind<CommonStatesMachineCoreGameplayState>().AsSingle();

            Container.BindInterfacesAndSelfTo<CommonStatesMachineService>().AsSingle().NonLazy();
        }
    }
}
