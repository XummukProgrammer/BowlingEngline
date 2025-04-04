using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityGameTemplate.Localizations.Models
{
    [CreateAssetMenu(fileName = "Resource", menuName = "Unity Game Template/Localizations/Resource")]
    public class UGTLocalizedResourceSO : ScriptableObject
    {
        [SerializeField]
        private UGTLocalizedLanguageResourceModel[] _resources;

        public IEnumerable<UGTLocalizedLanguageResourceModel> Resources => _resources;

        public UGTLocalizedLanguageResourceModel GetResource(UGTLanguageType languageType)
        {
            return _resources.FirstOrDefault(r => r.LanguageType == languageType);
        }
    }
}
