using System.Collections.Generic;
using UnityEngine;

namespace BowlingEngine.Services.AssetsLoader
{
    [CreateAssetMenu(fileName = "Package", menuName = "Bowling Engine/Static Data/Package")]
    public class AssetsLoaderPackageStaticData : ScriptableObject
    {
        [SerializeField]
        private AssetsLoaderPackageElementStaticData[] _elements;

        public IEnumerable<AssetsLoaderPackageElementStaticData> Elements => _elements;
    }
}
