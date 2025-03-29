using UGT.Basic.Data;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTGameplayInProgressState
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly UGTBasicData _basicData;
        private readonly UGTGameplayStatesMachineService _statesMachineService;

        public UGTGameplayInProgressState(
            UGTBasicData basicData, 
            UGTGameplayStatesMachineService statesMachineService)
        {
            _basicData = basicData;
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            Debug.Log("UGTGameplayInProgressState.Enter");
        }

        public void Exit()
        {
            Debug.Log("UGTGameplayInProgressState.Exit");
        }

        public void Tick()
        {
            if (_basicData.NewGameplayType != UGTGameplayType.Undefined)
            {
                _statesMachineService.EnterState<UGTGameplayUnloadState>();
            }
        }
    }
}
