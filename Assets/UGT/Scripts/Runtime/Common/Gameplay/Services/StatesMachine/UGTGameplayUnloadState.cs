using UGT.Basic.Data;
using UGT.Common.States;
using UGT.Services.Resources;
using UGT.Services.StatesMachine;
using UGT.Services.UI.HUD;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTBaseGameplayUnloadState<TMachine> : UGTUnloadState
        where TMachine : UGTStatesMachineService
    {
        private readonly UGTHudContainerService _hudContainerService;
        private readonly UGTBasicData _basicData;

        public UGTBaseGameplayUnloadState(
            UGTResourcesLoaderService resourcesLoaderService,
            UGTHudContainerService hudContainerService,
            UGTBasicData basicData) 
            : base(resourcesLoaderService)
        {
            _hudContainerService = hudContainerService;
            _basicData = basicData;
        }

        protected override void OnUnloaded()
        {
            _hudContainerService.UnloadAll();

            if (_basicData.NewGameplayType != UGTGameplayType.Undefined)
            {
                _basicData.ReadyToChangeGameplay = true;
            }
        }
    }

    public class UGTGameplayUnloadState : UGTBaseGameplayUnloadState<UGTGameplayStatesMachineService>
    {
        public UGTGameplayUnloadState(
            UGTResourcesLoaderService resourcesLoaderService, 
            UGTHudContainerService hudContainerService, 
            UGTBasicData basicData) 
            : base(resourcesLoaderService, 
                  hudContainerService, 
                  basicData)
        {
        }
    }
}
