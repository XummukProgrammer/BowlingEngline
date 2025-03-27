using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicBoostrapState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicStatesMachineService _statesMachineService;

        public UGTBasicBoostrapState(UGTBasicStatesMachineService statesMachineService)
        {
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            Debug.Log("UGTBasicBoostrapState.Enter");

            _statesMachineService.EnterState<UGTBasicGameplayLoadState>();
        }

        public void Exit()
        {
            Debug.Log("UGTBasicBoostrapState.Exit");
        }
    }
}
