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

        public GameObject Prefab {  get; private set; }
        public Transform Placeholder => _placeholder;
        public Vector3 Position => _position;
        public Quaternion Rotation => _rotation;

        protected override async Task LoadObject(GameObject result)
        {
            Prefab = result;
        }
    }
}
