using Zenject;

namespace UGT.Gameplay.Meta.Installers
{
    public class UGTMetaGameplayInstaller : MonoInstaller<UGTMetaGameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.InstallMeta();
        }
    }
}
