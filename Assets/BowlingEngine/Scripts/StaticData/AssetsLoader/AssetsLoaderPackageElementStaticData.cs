using BowlingEngine.Services.AssetsLoader;
using UnityEngine;

namespace BowlingEngine.StaticData.AssetsLoader
{
    [CreateAssetMenu(fileName = "Package Element", menuName = "Bowling Engine/Static Data/Package Element")]
    public class AssetsLoaderPackageElementStaticData : ScriptableObject
    {
        [SerializeField]
        private string _path;

        [SerializeField]
        private AssetLoaderObjectType _type;

        public string Path => _path;
        public AssetLoaderObjectType Type => _type;
    }
}
