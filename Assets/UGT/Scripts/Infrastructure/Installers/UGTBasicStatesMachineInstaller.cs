using UGT.StatesMachine;
using Zenject;

namespace UGT.Infrastructure.Installers
{
    public class UGTBasicStatesMachineInstaller : MonoInstaller<UGTBasicStatesMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UGTBasicBoostrapState>().AsSingle();
            Container.Bind<UGTBasicLoadState>().AsSingle();
            Container.Bind<UGTBasicUnloadState>().AsSingle();

            Container.BindInterfacesAndSelfTo<UGTBasicStatesMachineService>().AsSingle();
        }
    }
}
