using System.Collections.Generic;
using UnityEngine;

namespace UGT.Services.Localizations.Models
{
    [System.Serializable]
    public class UGTLanguageLocalizationModel
    {
        [SerializeField]
        private UGTLanguageType _type;

        [SerializeField]
        private UGTLocalizationElementModel[] _elements;

        public UGTLanguageType Type => _type;
        public IEnumerable<UGTLocalizationElementModel> Elements => _elements;
    }
}
