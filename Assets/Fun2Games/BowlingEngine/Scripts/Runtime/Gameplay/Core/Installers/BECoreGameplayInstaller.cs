using BowlingEngine.Gameplay.Core.Services;
using BowlingEngine.Gameplay.Core.States;
using UnityGameTemplate.Gameplay.Installers;
using UnityGameTemplate.Gameplay.States;

namespace BowlingEngine.Gameplay.Core.Installers
{
    public class BECoreGameplayInstaller : UGTGameplayInstaller
    {
        protected override void InstallStates()
        {
            Container.Bind<BECoreGameplayStatesBoostrap>().AsSingle();
            Container.Bind<BECoreGameplayStatesLoad>().AsSingle();
            Container.Bind<BECoreGameplayStatesStartFrame>().AsSingle();
            Container.Bind<BECoreGameplayStatesUnload>().AsSingle();
            Container.Bind<UGTGameplayStatesDisable>().AsSingle();

            Container.BindInterfacesAndSelfTo<BECoreGameplayStatesService>().AsSingle();
        }

        protected override void InstallSignalBus()
        {
            base.InstallSignalBus();
        }

        protected override void InstallResources()
        {
            Container.Bind<BECoreGameplayResourcesLoaderService>().AsSingle();
        }
    }
}
