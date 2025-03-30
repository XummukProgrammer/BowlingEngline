using UGT.Gameplay.Meta.Installers;
using Zenject;

namespace BowlingEngine.Gameplay.Meta.Installers
{
    public class BEMetaGameplayInstaller : MonoInstaller<BEMetaGameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallMeta();
            Container.InstallMetaStatesMachine();
        }
    }
}
