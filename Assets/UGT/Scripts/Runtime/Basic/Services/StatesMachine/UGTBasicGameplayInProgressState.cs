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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                InverseCurrentGameplay();

                _statesMachineService.EnterState<UGTBasicGameplayUnloadState>();
            }
        }

        private void InverseCurrentGameplay()
        {
            if (_basicData.GameplayType == UGTGameplayType.Meta)
            {
                _basicData.NewGameplayType = UGTGameplayType.Core;
            }
            else if (_basicData.GameplayType == UGTGameplayType.Core)
            {
                _basicData.NewGameplayType = UGTGameplayType.Meta;
            }
        }
    }
}
