using UnityGameTemplate.Localizations.Services;
using UnityGameTemplate.UI.Windows.Models;
using UnityGameTemplate.UI.Windows.Services;

namespace BowlingEngine.Common.UI.Windows.InfoWindow
{
    public class BEInfoWindowService : UGTWindowService
    {
        public override UGTWindowModel Model => _model;

        public BEInfoWindowTextType TextType
        {
            get => _textType;
            set
            {
                _textType = value;
                UpdateText();
            }
        }

        private BEInfoWindowView _view;
        private BEInfoWindowTextType _textType;

        private readonly BEInfoWindowModel _model;
        private readonly UGTLocalizationsService _localizationsService;

        public BEInfoWindowService(
            UGTWindowContainerService containerService,
            BEInfoWindowModel model,
            UGTLocalizationsService localizationsService) 
            : base(containerService)
        {
            _model = model;
            _localizationsService = localizationsService;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            _localizationsService.LocalizeTextsUpdated += OnLocalizeTextsUpdated;
        }

        public override void OnClose()
        {
            _localizationsService.LocalizeTextsUpdated -= OnLocalizeTextsUpdated;

            base.OnClose();
        }

        public override void OnViewInstantiate()
        {
            base.OnViewInstantiate();

            _view = View as BEInfoWindowView;
        }

        public override void OnViewRemove()
        {
            base.OnViewRemove();

            _view = null;
        }

        private void UpdateText()
        {
            if (_view == null)
            {
                return;
            }

            switch (_textType)
            {
                case BEInfoWindowTextType.SelectBall:
                    _view.Info = _localizationsService.GetLocalizeText(_model.SelectBallLocalizationID);
                    break;

                case BEInfoWindowTextType.FrameStep:
                    _view.Info = _localizationsService.GetLocalizeText(_model.FrameStepLocalizationID);
                    break;

                default:
                    _view.Info = "";
                    break;
            }
        }

        private void OnLocalizeTextsUpdated()
        {
            UpdateText();
        }
    }
}
