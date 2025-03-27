using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTGameplayBoostrapState : UGTIExitableState, UGTIEnterableState
    {
        private readonly UGTGameplayStatesMachineService _statesMachineService;
        private readonly UGTGameplayType _gameplayType;

        public UGTGameplayBoostrapState(
            UGTGameplayStatesMachineService statesMachineService, 
            UGTGameplayType gameplayType)
        {
            _statesMachineService = statesMachineService;
            _gameplayType = gameplayType;
        }

        public void Enter()
        {
            Debug.Log("UGTMetaBoostrapState.Enter");
            Debug.Log($"Gameplay type - {_gameplayType}");

            _statesMachineService.EnterState<UGTGameplayLoadState>();
        }

        public void Exit()
        {
            Debug.Log("UGTMetaBoostrapState.Exit");
        }
    }
}
