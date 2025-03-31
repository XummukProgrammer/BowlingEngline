using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.Signals;
using BowlingEngine.Gameplay.Core.States;
using UnityGameTemplate.Gameplay.Installers;
using UnityGameTemplate.Gameplay.States;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BECoreGameplayInstaller : UGTGameplayInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();

            InstallData();
        }

        protected override void InstallStates()
        {
            Container.Bind<BECoreGameplayStatesBoostrap>().AsSingle();
            Container.Bind<BECoreGameplayStatesLoad>().AsSingle();
            Container.Bind<BECoreGameplayStatesStartParty>().AsSingle();
            Container.Bind<BECoreGameplayStatesStartFrame>().AsSingle();
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
    }
}
