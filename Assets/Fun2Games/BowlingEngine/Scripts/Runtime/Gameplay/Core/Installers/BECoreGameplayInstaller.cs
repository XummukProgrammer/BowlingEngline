using BowlingEngine.Common.UI.Windows.InfoWindow;
using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Installers.Objects;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Objects.Pin;
using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.Services.Input;
using BowlingEngine.Gameplay.Core.Signals;
using BowlingEngine.Gameplay.Core.States;
using UnityEngine;
using UnityGameTemplate.Gameplay.Installers;
using UnityGameTemplate.Gameplay.States;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BECoreGameplayInstaller : UGTGameplayInstaller
    {
        private BECoreGameplayModel _gameplayModel;

        [Inject]
        public void Construct(BECoreGameplayModel gameplayModel)
        {
            _gameplayModel = gameplayModel;
        }

        public override void InstallBindings()
        {
            base.InstallBindings();

            InstallData();
            InstallInput();
            InstallObjectsFactories();
            InstallUI();
        }

        protected override void InstallStates()
        {
            Container.Bind<BECoreGameplayStatesBoostrap>().AsSingle();
            Container.Bind<BECoreGameplayStatesLoad>().AsSingle();
            Container.Bind<BECoreGameplayStatesStartParty>().AsSingle();
            Container.Bind<BECoreGameplayStatesStartFrame>().AsSingle();
            Container.Bind<BECoreGameplayStatesSelectBall>().AsSingle();
            Container.Bind<BECoreGameplayStatesStepFrame>().AsSingle();
            Container.Bind<BECoreGameplayStatesCheckFrame>().AsSingle();
            Container.Bind<BECoreGameplayStatesFinishFrame>().AsSingle();
            Container.Bind<BECoreGameplayStatesCheckParty>().AsSingle();
            Container.Bind<BECoreGameplayStatesFinishParty>().AsSingle();
            Container.Bind<BECoreGameplayStatesUnload>().AsSingle();
            Container.Bind<UGTGameplayStatesDisable>().AsSingle();

            Container.BindInterfacesAndSelfTo<BECoreGameplayStatesService>().AsSingle();
        }

        protected override void InstallSignalBus()
        {
            base.InstallSignalBus();

            Container.DeclareSignal<BEBallWorkedSignal>();
            Container.DeclareSignal<BEPinBounceSignal>();
            Container.DeclareSignal<BEBallSelectSignal>();
            Container.DeclareSignal<BEUserTriggeredSignal>();
        }

        protected override void InstallResources()
        {
            Container.Bind<BECoreGameplayResourcesLoaderService>().AsSingle();
        }

        private void InstallData()
        {
            Container.Bind<BECoreGameplayPartyData>().AsSingle();
            Container.Bind<BECoreGameplayFrameData>().AsSingle();
        }

        private void InstallInput()
        {
            Container.BindInterfacesAndSelfTo<BEDesktopInputService>().AsSingle();
        }

        private void InstallObjectsFactories()
        {
            Container.BindFactory<string, Vector2, Vector3, BEPinFacade, BEPinFactory>()
                .FromPoolableMemoryPool<string, Vector2, Vector3, BEPinFacade, BEPinPool>(poolBinder => poolBinder
                    .WithInitialSize(36)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<BEPinInstaller>(_gameplayModel.PinPrefab)
                    .UnderTransformGroup("Pins"));

            Container.Bind<BEPinRegistry>().AsSingle();
        }

        private void InstallUI()
        {
            InstallWindows();
        }

        private void InstallWindows()
        {
            Container.BindInterfacesAndSelfTo<BEInfoWindowService>().AsSingle();
        }
    }
}
