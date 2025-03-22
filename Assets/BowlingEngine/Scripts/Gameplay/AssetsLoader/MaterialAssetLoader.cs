using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.Gameplay.AssetsLoader
{
    public class MaterialAssetLoader : DynamicAssetLoader<Material>
    {
        protected override async Task LoadObject(Material result)
        {
            if (TryGetComponent(out MeshRenderer meshRenderer))
                meshRenderer.material = result;
        }
    }
}
