using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesGameplayInProgress
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly UGTStarterStatesService _statesService;
        private readonly UGTGameplayData _gameplayData;

        public UGTStarterStatesGameplayInProgress(
            UGTStarterStatesService statesService, 
            UGTGameplayData gameplayData)
        {
            _statesService = statesService;
            _gameplayData = gameplayData;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            if (_gameplayData.Disable)
            {
                _statesService.EnterState<UGTStarterStatesGameplayUnload>();
            }
        }
    }
}
