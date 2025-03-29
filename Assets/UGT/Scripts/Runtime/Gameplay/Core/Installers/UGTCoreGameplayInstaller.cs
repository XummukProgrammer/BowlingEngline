using Zenject;

namespace UGT.Gameplay.Core.Installers
{
    public class UGTCoreGameplayInstaller : MonoInstaller<UGTCoreGameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallCore();
        }
    }
}
