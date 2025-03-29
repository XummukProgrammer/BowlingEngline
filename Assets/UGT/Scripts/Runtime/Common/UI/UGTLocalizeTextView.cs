using TMPro;
using UGT.Services.Localizations;
using UnityEngine;
using Zenject;

namespace UGT.Common.UI
{
    public class UGTLocalizeTextView : MonoBehaviour
    {
        [SerializeField]
        private string _localizeKey = "Undefined";

        private UGTLocalizationsService _localizationsService;
        private TMP_Text _text;

        [Inject]
        public void Construct(UGTLocalizationsService localizationsService)
        {
            _localizationsService = localizationsService;
        }

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnEnable()
        {
            _localizationsService.LocalizeDataUpdated += OnLocalizeDataUpdated;
        }

        private void OnDisable()
        {
            _localizationsService.LocalizeDataUpdated -= OnLocalizeDataUpdated;
        }

        private void OnLocalizeDataUpdated()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            if (_text != null)
            {
                _text.text = _localizationsService.GetLocalize(_localizeKey);
            }
        }
    }
}
