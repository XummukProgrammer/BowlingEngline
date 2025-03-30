using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Pin;
using BowlingEngine.Gameplay.Core.Services.Input;
using BowlingEngine.Gameplay.Core.Services.StatesMachine;
using UGT.Gameplay.Core.Installers;
using UnityEngine;
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
            InstallStatesMachine();
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
            Container.BindFactory<Vector3, BEPinFacade, BEPinFacade.Factory>()
                .FromPoolableMemoryPool<Vector3, BEPinFacade, BEPinFacade.Pool>(poolBinder => poolBinder
                    .WithInitialSize(32)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<BEPinInstaller>(_coreGameplayModel.PinPrefab)
                    .UnderTransformGroup("Pins"));
        }

        private void InstallStatesMachine()
        {
            Container.Bind<BEStatesMachineBoostrapState>().AsSingle();
            Container.Bind<BEStatesMachineLoadState>().AsSingle();
            Container.Bind<BEStatesMachineInitFrameState>().AsSingle();
            Container.Bind<BEStatesMachineStepFrameState>().AsSingle();
            Container.Bind<BEStatesMachineUnloadState>().AsSingle();

            Container.BindInterfacesAndSelfTo<BEStatesMachineService>().AsSingle();
        }
    }
}
