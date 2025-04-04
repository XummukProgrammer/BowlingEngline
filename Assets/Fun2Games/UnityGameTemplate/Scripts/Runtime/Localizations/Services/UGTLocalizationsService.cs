using System;
using System.Collections.Generic;
using UnityGameTemplate.Localizations.Models;
using UnityGameTemplate.Localizations.ScriptableObjects;

namespace UnityGameTemplate.Localizations.Services
{
    public class UGTLocalizationsService
    {
        public event Action LocalizeTextsUpdated;

        public UGTLanguageType LanguageType { get; set; }

        private Dictionary<string, string> _localizeTexts = new();

        public void Load(UGTLocalizedLanguageSO localizedLanguageSO)
        {
            foreach (var localizedTextModel in localizedLanguageSO.Texts)
            {
                _localizeTexts[localizedTextModel.Key] = localizedTextModel.Value;
            }

            LocalizeTextsUpdated?.Invoke();
        }

        public void Unload(UGTLocalizedLanguageSO localizedLanguageSO)
        {
            foreach (var localizedTextModel in localizedLanguageSO.Texts)
            {
                _localizeTexts.Remove(localizedTextModel.Key);
            }

            LocalizeTextsUpdated?.Invoke();
        }

        public string GetLocalizeText(string key, string @default = null)
        {
            if (_localizeTexts.TryGetValue(key, out var text))
            {
                return text;
            }
            return @default ?? key;
        }
    }
}
