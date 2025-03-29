using System;
using System.Collections.Generic;
using System.Linq;
using UGT.Services.Localizations.Models;

namespace UGT.Services.Localizations
{
    public class UGTLocalizationsService
    {
        public event Action LocalizeDataUpdated;

        private UGTLanguageType _currentLanguage = UGTLanguageType.Russian;
        private Dictionary<string, string> _localizeData = new();

        public void SetCurrentLanguage(UGTLanguageType language)
        {
            _currentLanguage = language;
        }

        public void LoadLocalizeData(UGTLocalizationModel localizationModel)
        {
            var languageLocalizationModel = localizationModel.Languages.FirstOrDefault(l => l.Type == _currentLanguage);
            if (languageLocalizationModel != null)
            {
                foreach (var element in languageLocalizationModel.Elements)
                {
                    _localizeData[element.Key] = element.Value;
                }
            }

            LocalizeDataUpdated?.Invoke();
        }

        public void UnloadLocalizeData(UGTLocalizationModel localizationModel)
        {
            var languageLocalizationModel = localizationModel.Languages.FirstOrDefault(l => l.Type == _currentLanguage);
            if (languageLocalizationModel != null)
            {
                foreach (var element in languageLocalizationModel.Elements)
                {
                    _localizeData.Remove(element.Key);
                }
            }

            LocalizeDataUpdated?.Invoke();
        }

        public string GetLocalize(string key, string @default = null)
        {
            if (_localizeData.TryGetValue(key, out var value))
            {
                return value;
            }
            return @default ?? key;
        }
    }
}
