using UGT.Gameplay.Core.Installers;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BECoreGameplayInstaller : MonoInstaller<BECoreGameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallCore();
        }
    }
}
