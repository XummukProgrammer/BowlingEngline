using UnityGameTemplate.UI.HUD.Models;
using UnityGameTemplate.UI.HUD.Services;

namespace UnityGameTemplate.UI.HUD.Common.Message
{
    public class UGTMessageHUDService : UGTHUDService
    {
        public override UGTHUDModel Model => _model;

        private UGTMessageHUDView _view;

        private readonly UGTMessageHUDModel _model;

        public UGTMessageHUDService(
            UGTHUDContainerService hudContainerService,
            UGTMessageHUDModel model) 
            : base(hudContainerService)
        {
            _model = model;
        }

        public void ShowText(UGTMessageHUDPlaceType placeType, string text, float time = 3)
        {
            if (_view != null)
            {
                bool isUnlimitedTime = placeType == UGTMessageHUDPlaceType.Info;

                _view.ShowText(placeType, text, time, isUnlimitedTime);
            }
        }

        public override void OnViewInstantiate()
        {
            base.OnViewInstantiate();

            _view = View as UGTMessageHUDView;
        }

        public override void OnViewRemove()
        {
            base.OnViewRemove();

            _view = null;
        }
    }
}
