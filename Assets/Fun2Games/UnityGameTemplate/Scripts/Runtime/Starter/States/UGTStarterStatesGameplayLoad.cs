using System.Threading.Tasks;
using UnityGameTemplate.Resources.Services;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.Starter.Models;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesGameplayLoad
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTStarterStatesService _statesService;
        private readonly UGTGameplayData _gameplayData;
        private readonly UGTGameplaySceneModel _gameplaySceneModel;
        private readonly UGTResourcesService _resourcesService;

        public UGTStarterStatesGameplayLoad(
            UGTStarterStatesService statesService,
            UGTGameplayData gameplayData,
            UGTGameplaySceneModel gameplaySceneModel,
            UGTResourcesService resourcesService)
        {
            _statesService = statesService;
            _gameplayData = gameplayData;
            _gameplaySceneModel = gameplaySceneModel;
            _resourcesService = resourcesService;
        }

        public void Enter()
        {
            _ = LoadScene();
        }

        public void Exit()
        {
        }

        private async Task LoadScene()
        {
            _gameplayData.ReadyToBoostrap = false;
            _gameplayData.Disable = false;

            var sceneResource = _gameplaySceneModel.GetSceneResource(_gameplayData.CurrentType);
            if (sceneResource != null)
            {
                await _resourcesService.Load(sceneResource);
            }

            _gameplayData.ReadyToBoostrap = true;

            _statesService.EnterState<UGTStarterStatesGameplayInProgress>();
        }
    }
}
