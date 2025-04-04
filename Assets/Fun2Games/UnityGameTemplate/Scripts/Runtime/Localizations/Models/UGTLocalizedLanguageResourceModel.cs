using UnityEngine;

namespace UnityGameTemplate.Localizations.Models
{
    [System.Serializable]
    public class UGTLocalizedLanguageResourceModel
    {
        [SerializeField]
        private UGTLanguageType _languageType;

        [SerializeField]
        private string _resourceID;

        public UGTLanguageType LanguageType => _languageType;
        public string ResourceID => _resourceID;
    }
}
