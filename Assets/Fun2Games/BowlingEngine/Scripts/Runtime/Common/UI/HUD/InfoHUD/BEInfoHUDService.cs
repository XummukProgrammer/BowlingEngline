using System;
using UnityGameTemplate.Localizations.Services;
using UnityGameTemplate.UI.HUD.Common.Message;
using Zenject;

namespace BowlingEngine.Common.UI.HUD.InfoHUD
{
    public class BEInfoHUDService
        : IInitializable
        , IDisposable
    {
        public BEInfoHUDTextType CurrentTextType
        {
            get => _currentTextType;
            set
            {
                _currentTextType = value;
                OnUpdateText();
            }
        }

        private readonly BEInfoHUDModel _model;
        private UGTMessageHUDService _messageHUDService;
        private UGTLocalizationsService _localizationsService;
        private BEInfoHUDTextType _currentTextType = BEInfoHUDTextType.None;

        public BEInfoHUDService(
            BEInfoHUDModel model,
            UGTMessageHUDService messageHUDService,
            UGTLocalizationsService localizationsService)
        {
            _model = model;
            _messageHUDService = messageHUDService;
            _localizationsService = localizationsService;
        }

        public void Initialize()
        {
            _localizationsService.LocalizeTextsUpdated += OnLocalizeTextsUpdated;
        }

        public void Dispose()
        {
            _localizationsService.LocalizeTextsUpdated -= OnLocalizeTextsUpdated;
        }

        private void OnUpdateText()
        {
            string text = string.Empty;
            switch (_currentTextType)
            {
                case BEInfoHUDTextType.SelectBall:
                    text = _localizationsService.GetLocalizeText(_model.SelectBallLocalizationID);
                    break;

                case BEInfoHUDTextType.FrameStep:
                    text = _localizationsService.GetLocalizeText(_model.FrameStepLocalizationID);
                    break;

                default:
                    text = "";
                    break;
            }

            _messageHUDService.ShowText(UGTMessageHUDPlaceType.Info, text);
        }

        private void OnLocalizeTextsUpdated()
        {
            OnUpdateText();
        }
    }
}
