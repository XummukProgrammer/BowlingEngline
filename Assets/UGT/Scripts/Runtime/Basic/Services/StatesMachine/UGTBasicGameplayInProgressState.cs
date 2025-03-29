using UGT.Basic.Data;
using UGT.Common.Gameplay;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicGameplayInProgressState
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly UGTBasicData _basicData;
        private readonly UGTBasicStatesMachineService _statesMachineService;

        public UGTBasicGameplayInProgressState(
            UGTBasicData basicData, 
            UGTBasicStatesMachineService statesMachineService)
        {
            _basicData = basicData;
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            Debug.Log("UGTBasicGameplayInProgressState.Enter");
        }

        public void Exit()
        {
            Debug.Log("UGTBasicGameplayInProgressState.Exit");
        }

        public void Tick()
        {
            if (_basicData.ReadyToChangeGameplay && _basicData.NewGameplayType != UGTGameplayType.Undefined)
            {
                _statesMachineService.EnterState<UGTBasicGameplayUnloadState>();
            }
        }
    }
}
