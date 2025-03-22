using UnityEngine;

namespace BowlingEngine.Gameplay.AssetsLoader
{
    public class MaterialAssetLoader : DynamicAssetLoader<Material>
    {
        protected override void LoadObject(Material result)
        {
            if (TryGetComponent(out MeshRenderer meshRenderer))
                meshRenderer.material = result;
        }
    }
}
