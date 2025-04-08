using UnityGameTemplate.Gameplay.Signals;
using UnityGameTemplate.UI.HUD.Models;
using UnityGameTemplate.UI.HUD.Services;
using Zenject;

namespace UnityGameTemplate.Gameplay.HUD.Disable
{
    public class UGTGameplayDisableHUDService : UGTHUDService
    {
        public override UGTHUDModel Model => _model;

        private readonly UGTGameplayDisableHUDModel _model;
        private readonly SignalBus _signalBus;

        public UGTGameplayDisableHUDService(
            UGTHUDContainerService hudContainerService,
            UGTGameplayDisableHUDModel model,
            SignalBus signalBus) 
            : base(hudContainerService)
        {
            _model = model;
            _signalBus = signalBus;
        }

        protected override void OnClicked()
        {
            base.OnClicked();

            _signalBus.Fire<UGTGameplayDisableSignal>();
        }
    }
}
