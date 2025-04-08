using UnityGameTemplate.Gameplay.Signals;
using UnityGameTemplate.UI.HUD.Models;
using UnityGameTemplate.UI.HUD.Services;
using Zenject;

namespace UnityGameTemplate.Gameplay.HUD.Change
{
    public class UGTGameplayChangeHUDService : UGTHUDService
    {
        public override UGTHUDModel Model => _model;

        private readonly UGTGameplayChangeHUDModel _model;
        private readonly SignalBus _signalBus;

        public UGTGameplayChangeHUDService(
            UGTHUDContainerService hudContainerService,
            UGTGameplayChangeHUDModel model,
            SignalBus signalBus) 
            : base(hudContainerService)
        {
            _model = model;
            _signalBus = signalBus;
        }

        protected override void OnClicked()
        {
            base.OnClicked();

            _signalBus.Fire<UGTGameplayChangeSignal>();
        }
    }
}
