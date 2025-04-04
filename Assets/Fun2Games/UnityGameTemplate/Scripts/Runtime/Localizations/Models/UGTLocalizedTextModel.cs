using UnityEngine;

namespace UnityGameTemplate.Localizations.Models
{
    [System.Serializable]
    public class UGTLocalizedTextModel
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private string _value;

        public string Key => _key;
        public string Value => _value;
    }
}
