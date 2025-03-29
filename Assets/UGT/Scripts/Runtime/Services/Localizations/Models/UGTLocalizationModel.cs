using System.Collections.Generic;
using UnityEngine;

namespace UGT.Services.Localizations.Models
{
    [System.Serializable]
    public class UGTLocalizationModel
    {
        [SerializeField]
        private UGTLanguageLocalizationModel[] _languages;

        public IEnumerable<UGTLanguageLocalizationModel> Languages => _languages;
    }
}
