using UGT.Basic.Data;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTBaseGameplayInProgressState<TMachine, TNextState>
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
        where TMachine : UGTStatesMachineService
        where TNextState : UGTIExitableState
    {
        private readonly UGTBasicData _basicData;
        private readonly TMachine _statesMachineService;

        public UGTBaseGameplayInProgressState(
            UGTBasicData basicData,
            TMachine statesMachineService)
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
                _statesMachineService.EnterState<TNextState>();
            }
        }
    }

    public class UGTGameplayInProgressState : UGTBaseGameplayInProgressState<UGTGameplayStatesMachineService, UGTGameplayUnloadState>
    {
        public UGTGameplayInProgressState(
            UGTBasicData basicData, 
            UGTGameplayStatesMachineService statesMachineService) 
            : base(basicData, statesMachineService)
        {
        }
    }
}
