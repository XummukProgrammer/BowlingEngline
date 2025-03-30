using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Pin;
using BowlingEngine.Gameplay.Core.Services.Input;
using BowlingEngine.Gameplay.Core.Services.StatesMachine;
using UGT.Common.Factories;
using UGT.Common.Gameplay.Services.StatesMachine;
using UGT.Common.Gameplay.UI.HUD;
using UGT.Gameplay.Core.Installers;
using UGT.Services.Resources;
using YG;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BECoreGameplayInstaller : MonoInstaller<BECoreGameplayInstaller>
    {
        private BECoreGameplayModel _coreGameplayModel;

        [Inject]
        public void Construct(BECoreGameplayModel coreGameplayModel)
        {
            _coreGameplayModel = coreGameplayModel;
        }

        public override void InstallBindings()
        {
            Container.InstallCore();

            InstallInput();
            InstallFactories();
        }

        private void InstallInput()
        {
            if (YG2.envir.device == YG2.Device.Desktop)
            {
                Container.BindInterfacesAndSelfTo<BEDesktopInputService>().AsSingle();
            }
        }

        private void InstallFactories()
        {
            Container.BindFactory<BEPinFacade, BEPinFacade.Factory>()
                .FromPoolableMemoryPool<BEPinFacade, BEPinFacade.Pool>(poolBinder => poolBinder
                    .WithInitialSize(32)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<BEPinInstaller>(_coreGameplayModel.PinPrefab)
                    .UnderTransformGroup("Pins"));
        }
    }
}
