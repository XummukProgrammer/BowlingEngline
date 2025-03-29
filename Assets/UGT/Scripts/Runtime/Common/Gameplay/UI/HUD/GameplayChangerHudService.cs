using UGT.Basic.Data;
using UGT.Services.UI.HUD;
using UGT.Services.UI.Models;

namespace UGT.Common.Gameplay.UI.HUD
{
    public class GameplayChangerHudService : UGTHudService
    {
        public override UGTHudModel Model => _model;

        protected override UGTHudService This => this;

        private readonly GameplayChangerHudModel _model;
        private readonly UGTBasicData _basicData;

        public GameplayChangerHudService(
            UGTHudContainerService hudContainerService,
            GameplayChangerHudModel model,
            UGTBasicData basicData) 
            : base(hudContainerService)
        {
            _model = model;
            _basicData = basicData;
        }

        protected override void OnClicked()
        {
            base.OnClicked();

            _basicData.NewGameplayType = _model.GameplayType;
        }
    }
}
