using UGT.StatesMachine;
using Zenject;

namespace UGT.Infrastructure.Installers
{
    public class UGTBasicStatesMachineInstaller : MonoInstaller<UGTBasicStatesMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UGTBasicBoostrapState>().AsSingle();
            Container.Bind<UGTBasicGameplayLoadState>().AsSingle();
            Container.Bind<UGTBasicGameplayUnloadState>().AsSingle();
            Container.Bind<UGTBasicGameplayInProgressState>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTBasicStatesMachineService>().AsSingle();
        }
    }
}
