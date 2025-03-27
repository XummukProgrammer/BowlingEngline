using System.Threading.Tasks;
using UGT.Basic.Data;
using UGT.Basic.Models;
using UGT.Services.Resources;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicGameplayLoadState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicModel _basicModel;
        private readonly UGTBasicData _basicData;
        private readonly UGTResourcesService _resourcesService;
        private readonly UGTBasicStatesMachineService _statesMachineService;

        public UGTBasicGameplayLoadState(
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
            Debug.Log("UGTBasicGameplayLoadState.Enter");

            _ = Load();
        }

        public void Exit()
        {
            Debug.Log("UGTBasicGameplayLoadState.Exit");
        }

        private async Task Load()
        {
            await _resourcesService.Load(_basicModel.GetResources(_basicData.GameplayType));

            _statesMachineService.EnterState<UGTBasicGameplayInProgressState>();
        }
    }
}
