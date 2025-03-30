using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTBaseGameplayBoostrapState<TMachine, TNextState> : UGTIExitableState, UGTIEnterableState
        where TMachine : UGTStatesMachineService
        where TNextState : UGTIExitableState
    {
        private readonly TMachine _statesMachineService;
        private readonly UGTGameplayType _gameplayType;

        public UGTBaseGameplayBoostrapState(
            TMachine statesMachineService, 
            UGTGameplayType gameplayType)
        {
            _statesMachineService = statesMachineService;
            _gameplayType = gameplayType;
        }

        public void Enter()
        {
            Debug.Log("UGTMetaBoostrapState.Enter");
            Debug.Log($"Gameplay type - {_gameplayType}");

            _statesMachineService.EnterState<TNextState>();
        }

        public void Exit()
        {
            Debug.Log("UGTMetaBoostrapState.Exit");
        }
    }

    public class UGTGameplayBoostrapState : UGTBaseGameplayBoostrapState<UGTGameplayStatesMachineService, UGTGameplayLoadState>
    {
        public UGTGameplayBoostrapState(
            UGTGameplayStatesMachineService statesMachineService, 
            UGTGameplayType gameplayType) 
            : base(statesMachineService, gameplayType)
        {
        }
    }
}
