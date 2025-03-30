using UGT.Basic.Data;
using UGT.Common.States;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTBaseGameplayInProgressState<TMachine, TNextState> : UGTGameplayChangerableState<TMachine, TNextState>
        where TMachine : UGTStatesMachineService
        where TNextState : UGTIExitableState
    {
        public UGTBaseGameplayInProgressState(
            UGTBasicData basicData, 
            TMachine statesMachineService) 
            : base(basicData, 
                  statesMachineService)
        {
        }
    }

    public class UGTGameplayInProgressState : UGTBaseGameplayInProgressState<UGTGameplayStatesMachineService, UGTGameplayUnloadState>
    {
        public UGTGameplayInProgressState(
            UGTBasicData basicData, 
            UGTGameplayStatesMachineService statesMachineService) 
            : base(basicData, 
                  statesMachineService)
        {
        }
    }
}
