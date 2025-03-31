using UnityGameTemplate.Gameplay.Models;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesGameplayChange
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTGameplayData _gameplayData;
        private readonly UGTStarterStatesService _statesService;

        public UGTStarterStatesGameplayChange(
            UGTGameplayData gameplayData, 
            UGTStarterStatesService statesService)
        {
            _gameplayData = gameplayData;
            _statesService = statesService;
        }

        public void Enter()
        {
            if (_gameplayData.CurrentType == UGTGameplayType.Meta)
            {
                _gameplayData.CurrentType = UGTGameplayType.Core;
            }
            else if (_gameplayData.CurrentType == UGTGameplayType.Core)
            {
                _gameplayData.CurrentType = UGTGameplayType.Meta;
            }

            _statesService.EnterState<UGTStarterStatesGameplayLoad>();
        }

        public void Exit()
        {
        }
    }
}
