using System.Threading.Tasks;
using UGT.Common.States;
using UGT.Services.Resources;
using UGT.Services.UI.HUD;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTGameplayLoadState : UGTLoadState
    {
        private readonly UGTHudContainerService _hudContainerService;
        private readonly UGTGameplayStatesMachineService _statesMachineService;

        public UGTGameplayLoadState(
            UGTResourcesLoaderService resourcesLoaderService,
            UGTHudContainerService hudContainerService,
            UGTGameplayStatesMachineService statesMachineService) 
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

            _statesMachineService.EnterState<UGTGameplayInProgressState>();
        }
    }
}
