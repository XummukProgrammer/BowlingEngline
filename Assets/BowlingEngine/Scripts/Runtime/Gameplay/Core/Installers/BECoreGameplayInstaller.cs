using BowlingEngine.Gameplay.Core.Services.Input;
using UGT.Gameplay.Core.Installers;
using YG;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BECoreGameplayInstaller : MonoInstaller<BECoreGameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallCore();

            if (YG2.envir.device == YG2.Device.Desktop)
            {
                Container.BindInterfacesAndSelfTo<BEDesktopInputService>().AsSingle();
            }
        }
    }
}
