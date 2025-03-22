using UnityEngine;

namespace BowlingEngine.Services.AssetsLoader
{
    [System.Serializable]
    public class AssetsLoaderPackageData
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private string _path;

        [SerializeField]
        private AssetLoaderObjectType _type;

        public string Id => _id;
        public string Path => _path;
        public AssetLoaderObjectType Type => _type;
    }
}
