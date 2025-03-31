using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityGameTemplate.Resources.Interfaces;

namespace UnityGameTemplate.Resources.Implementation
{
    public class UGTSceneResource : UGTIResource
    {
        public string ID { get; private set; }
        public string Path { get; private set; }

        private SceneInstance _sceneInstance;

        public UGTSceneResource(string id, string path)
        {
            ID = id;
            Path = path;
        }

        public async Task Load()
        {
            _sceneInstance = await Addressables.LoadSceneAsync(Path, UnityEngine.SceneManagement.LoadSceneMode.Additive).Task;
        }

        public async Task Unload()
        {
            await Addressables.UnloadSceneAsync(_sceneInstance).Task;
        }
    }
}
