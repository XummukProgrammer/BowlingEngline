using BowlingEngine.Gameplay.Core.Pin;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BEPinInstaller : Installer<BEPinInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BEPinState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BEPinPhysicsInitializer>().AsSingle();
            Container.Bind<BEPinBounceHandler>().AsSingle();
        }
    }
}
