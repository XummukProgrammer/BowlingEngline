using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.Localizations.Models;

namespace UnityGameTemplate.Localizations.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Language", menuName = "Unity Game Template/Localizations/Language")]
    public class UGTLocalizedLanguageSO : ScriptableObject
    {
        [SerializeField]
        private UGTLocalizedTextModel[] _texts;

        public IEnumerable<UGTLocalizedTextModel> Texts => _texts;
    }
}
