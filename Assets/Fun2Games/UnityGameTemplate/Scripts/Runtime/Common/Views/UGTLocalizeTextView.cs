using UnityEngine;
using UnityGameTemplate.Localizations.Services;
using Zenject;

namespace UnityGameTemplate.Common.Views
{
    public class UGTLocalizeTextView : MonoBehaviour
    {
        [SerializeField]
        private string _key = "Undefined";

        [SerializeField]
        private bool _isDefaultBaseText = false;

        private UGTLocalizationsService _localizationsService;
        private TMPro.TMP_Text _text;

        [Inject]
        public void Construct(UGTLocalizationsService localizationsService)
        {
            _localizationsService = localizationsService;
        }

        private void Awake()
        {
            if (TryGetComponent(out TMPro.TMP_Text text))
            {
                _text = text;
                UpdateText();
            }
        }

        public void Dispose()
        {
            _localizationsService.LocalizeTextsUpdated -= UpdateText;
        }

        private void OnEnable()
        {
            _localizationsService.LocalizeTextsUpdated += UpdateText;
        }

        private void OnDisable()
        {
            _localizationsService.LocalizeTextsUpdated -= UpdateText;
        }

        private void UpdateText()
        {
            if (_text != null)
            {
                _text.text = _localizationsService.GetLocalizeText(
                    _key,
                    _isDefaultBaseText ? _text.text : null);
            }
        }
    }
}
