using System.Threading.Tasks;
using UGT.Basic.Data;
using UGT.Basic.Models;
using UGT.Common.Gameplay;
using UGT.Services.Resources;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicGameplayUnloadState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicModel _basicModel;
        private readonly UGTBasicData _basicData;
        private readonly UGTResourcesService _resourcesService;
        private readonly UGTBasicStatesMachineService _statesMachineService;

        public UGTBasicGameplayUnloadState(
            UGTBasicModel basicModel,
            UGTBasicData basicData,
            UGTResourcesService resourcesService,
            UGTBasicStatesMachineService statesMachineService)
        {
            _basicModel = basicModel;
            _basicData = basicData;
            _resourcesService = resourcesService;
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            Debug.Log("UGTBasicGameplayUnloadState.Enter");

            _ = Unload();
        }

        public void Exit()
        {
            Debug.Log("UGTBasicGameplayUnloadState.Exit");
        }

        private async Task Unload()
        {
            await _resourcesService.Unload(_basicModel.GetResources(_basicData.GameplayType));

            if (_basicData.NewGameplayType != UGTGameplayType.Undefined)
            {
                _statesMachineService.EnterState<UGTBasicGameplayChangeState>();
            }
        }
    }
}
