using UGT.Services.Localizations.Models;
using UGT.Services.Resources.Interfaces;
using UGT.Services.Resources.Models;
using UGT.Services.Resources.ScriptableObjects;
using UnityEngine;

namespace UGT.Services.Localizations.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Localizations Asset", menuName = "UGT/Assets/Resources/Localizations", order = 3)]
    public class UGTLocalizationsResourceAsset : UGTResourceAsset
    {
        [SerializeField]
        private UGTLocalizationModel _model;

        public override UGTResourceDependencyType[] Dependencies => new[] { UGTResourceDependencyType.Localizations };

        public override UGTIResource CreateInstance(UGTResourceDependenciesModel dependencies)
        {
            return new UGTLocalizationsResource(dependencies.Localizations, _model);
        }
    }
}
