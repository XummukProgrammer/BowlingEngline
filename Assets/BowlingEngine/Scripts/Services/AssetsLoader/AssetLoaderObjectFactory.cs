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
                default:
                    break;
            }
            return null;
        }
    }
}
