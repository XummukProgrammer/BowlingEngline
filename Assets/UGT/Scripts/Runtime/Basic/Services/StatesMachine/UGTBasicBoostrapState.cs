using UGT.Basic.Data;
using UGT.Basic.Models;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicBoostrapState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicStatesMachineService _statesMachineService;
        private readonly UGTBasicModel _basicModel;
        private readonly UGTBasicData _basicData;

        public UGTBasicBoostrapState(
            UGTBasicStatesMachineService statesMachineService,
            UGTBasicModel basicModel,
            UGTBasicData basicData)
        {
            _statesMachineService = statesMachineService;
            _basicModel = basicModel;
            _basicData = basicData;
        }

        public void Enter()
        {
            Debug.Log("UGTBasicBoostrapState.Enter");

            _basicData.GameplayType = _basicModel.DefaultGameplayType;

            _statesMachineService.EnterState<UGTBasicGameplayLoadState>();
        }

        public void Exit()
        {
            Debug.Log("UGTBasicBoostrapState.Exit");
        }
    }
}
