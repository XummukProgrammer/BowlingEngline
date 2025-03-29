using UnityEngine;

namespace UGT.Services.Localizations.Models
{
    [System.Serializable]
    public class UGTLocalizationElementModel
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private string _value;

        public string Key => _key;
        public string Value => _value;
    }
}
