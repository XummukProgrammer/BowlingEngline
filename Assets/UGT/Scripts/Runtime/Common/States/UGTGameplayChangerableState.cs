using UGT.Basic.Data;
using UGT.Common.Gameplay;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;
using Zenject;

namespace UGT.Common.States
{
    public class UGTGameplayChangerableState<TMachine, TNextState>
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
        where TMachine : UGTStatesMachineService
        where TNextState : UGTIExitableState
    {
        private readonly UGTBasicData _basicData;
        private readonly TMachine _statesMachineService;

        public UGTGameplayChangerableState(
            UGTBasicData basicData,
            TMachine statesMachineService)
        {
            _basicData = basicData;
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            Debug.Log("UGTGameplayChangerableState.Enter");
        }

        public void Exit()
        {
            Debug.Log("UGTGameplayChangerableState.Exit");
        }

        public void Tick()
        {
            if (_basicData.NewGameplayType != UGTGameplayType.Undefined)
            {
                _statesMachineService.EnterState<TNextState>();
            }
        }
    }
}
