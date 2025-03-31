using UnityGameTemplate.Gameplay.Services;
using UnityGameTemplate.Gameplay.Signals;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesInProgress
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTGameplayStatesService _statesService;
        private readonly SignalBus _signalBus;
        private readonly UGTGameplayData _gameplayData;

        public UGTGameplayStatesInProgress(
            UGTGameplayStatesService statesService, 
            SignalBus signalBus,
            UGTGameplayData gameplayData)
        {
            _statesService = statesService;
            _signalBus = signalBus;
            _gameplayData = gameplayData;
        }

        public void Enter()
        {
            _signalBus.Subscribe<UGTGameplayDisableSignal>(OnGameplayDisabled);
            _signalBus.Subscribe<UGTGameplayChangeSignal>(OnGameplayChanged);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<UGTGameplayDisableSignal>(OnGameplayDisabled);
            _signalBus.Unsubscribe<UGTGameplayChangeSignal>(OnGameplayChanged);
        }

        private void OnGameplayDisabled()
        {
            _statesService.EnterState<UGTGameplayStatesUnload>();
        }

        private void OnGameplayChanged()
        {
            _gameplayData.Change = true;

            _statesService.EnterState<UGTGameplayStatesUnload>();
        }
    }
}
