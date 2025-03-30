using System.Threading.Tasks;
using UGT.Common.States;
using UGT.Services.Resources;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;
using UGT.Services.UI.HUD;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTBaseGameplayLoadState<TMachine, TNextState> : UGTLoadState
        where TMachine : UGTStatesMachineService
        where TNextState : UGTIExitableState
    {
        private readonly UGTHudContainerService _hudContainerService;
        private readonly TMachine _statesMachineService;

        public UGTBaseGameplayLoadState(
            UGTResourcesLoaderService resourcesLoaderService,
            UGTHudContainerService hudContainerService,
            TMachine statesMachineService) 
            : base(resourcesLoaderService)
        {
            _hudContainerService = hudContainerService;
            _statesMachineService = statesMachineService;
        }

        protected override void OnLoaded()
        {
            _ = CreateAll();
        }

        private async Task CreateAll()
        {
            await _hudContainerService.CreateAll();

            _statesMachineService.EnterState<TNextState>();
        }
    }

    public class UGTGameplayLoadState : UGTBaseGameplayLoadState<UGTGameplayStatesMachineService, UGTGameplayInProgressState>
    {
        public UGTGameplayLoadState(
            UGTResourcesLoaderService resourcesLoaderService, 
            UGTHudContainerService hudContainerService, 
            UGTGameplayStatesMachineService statesMachineService) 
            : base(resourcesLoaderService, 
                  hudContainerService, 
                  statesMachineService)
        {
        }
    }
}
