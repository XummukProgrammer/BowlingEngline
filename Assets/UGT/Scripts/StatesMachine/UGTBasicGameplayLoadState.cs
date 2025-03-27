using System.Threading.Tasks;
using UGT.Infrastructure.Models;
using UGT.Services.Resources;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.StatesMachine
{
    public class UGTBasicGameplayLoadState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicModel _basicModel;
        private readonly UGTResourcesService _resourcesService;
        private readonly UGTBasicStatesMachineService _statesMachineService;

        public UGTBasicGameplayLoadState(
            UGTBasicModel basicModel, 
            UGTResourcesService resourcesService,
            UGTBasicStatesMachineService statesMachineService)
        {
            _basicModel = basicModel;
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
            await _resourcesService.Load(_basicModel.DefaultResources);

            _statesMachineService.EnterState<UGTBasicGameplayInProgressState>();
        }
    }
}
