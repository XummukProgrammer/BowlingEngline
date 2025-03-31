using UnityGameTemplate.Gameplay.Services;
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

        public UGTGameplayStatesInProgress(
            UGTGameplayStatesService statesService, 
            SignalBus signalBus)
        {
            _statesService = statesService;
            _signalBus = signalBus;
        }

        public void Enter()
        {
            _signalBus.Subscribe<UGTGameplayDisableSignal>(OnGameplayDisabled);
        }

        public void Exit()
        {
            _signalBus.Unsubscribe<UGTGameplayDisableSignal>(OnGameplayDisabled);
        }

        private void OnGameplayDisabled()
        {
            _statesService.EnterState<UGTGameplayStatesUnload>();
        }
    }
}
