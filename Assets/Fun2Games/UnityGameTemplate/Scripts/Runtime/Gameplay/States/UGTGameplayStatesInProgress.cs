using UnityGameTemplate.Gameplay.Services;
using UnityGameTemplate.Gameplay.Signals;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;
using Zenject;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTBaseGameplayStatesInProgress<TMachine, TNextState>
        : UGTIExitableState
        , UGTIEnterableState
        where TMachine : UGTBaseStatesService
        where TNextState : UGTIExitableState
    {
        private readonly TMachine _statesService;
        private readonly SignalBus _signalBus;
        private readonly UGTGameplayData _gameplayData;

        public UGTBaseGameplayStatesInProgress(
            TMachine statesService, 
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
            _statesService.EnterState<TNextState>();
        }

        private void OnGameplayChanged()
        {
            _gameplayData.Change = true;

            _statesService.EnterState<TNextState>();
        }
    }

    public class UGTGameplayStatesInProgress
        : UGTBaseGameplayStatesInProgress<UGTGameplayStatesService, UGTGameplayStatesUnload>
    {
        public UGTGameplayStatesInProgress(
            UGTGameplayStatesService statesService, 
            SignalBus signalBus, 
            UGTGameplayData gameplayData) 
            : base(statesService, 
                  signalBus, 
                  gameplayData)
        {
        }
    }
}
