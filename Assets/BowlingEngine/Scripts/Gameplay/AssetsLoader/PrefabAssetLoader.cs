using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.Gameplay.AssetsLoader
{
    public class PrefabAssetLoader : DynamicAssetLoader<GameObject>
    {
        [SerializeField]
        private Transform _placeholder;

        [SerializeField]
        private Vector3 _position = Vector3.zero;

        [SerializeField]
        private Quaternion _rotation = Quaternion.identity;

        protected override async Task LoadObject(GameObject result)
        {
            await InstantiateAsync(result, _placeholder, _position, _rotation);
        }
    }
}
