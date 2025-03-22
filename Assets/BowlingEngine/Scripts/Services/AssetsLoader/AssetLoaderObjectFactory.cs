using UnityEngine;

namespace BowlingEngine.Services.AssetsLoader
{
    public static class AssetLoaderObjectFactory
    {
        public static IAssetLoaderObject Build(AssetLoaderObjectType type)
        {
            switch (type)
            {
                case AssetLoaderObjectType.Scene:
                    return new AssetLoaderObjectScene();
                case AssetLoaderObjectType.Prefab:
                    return new AssetLoaderObjectDynamic<GameObject>();
                default:
                    break;
            }
            return null;
        }
    }
}
