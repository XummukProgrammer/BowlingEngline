using UGT.Basic.Data;
using UGT.Common.Gameplay;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicGameplayChangeState
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicData _basicData;
        private readonly UGTBasicStatesMachineService _statesMachineService;

        public UGTBasicGameplayChangeState(
            UGTBasicData basicData, 
            UGTBasicStatesMachineService statesMachineService)
        {
            _basicData = basicData;
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            Debug.Log("UGTBasicGameplayChangeState.Enter");

            _basicData.GameplayType = _basicData.NewGameplayType;
            _basicData.NewGameplayType = UGTGameplayType.Undefined;

            _statesMachineService.EnterState<UGTBasicGameplayLoadState>();
        }

        public void Exit()
        {
            Debug.Log("UGTBasicGameplayChangeState.Exit");
        }
    }
}
