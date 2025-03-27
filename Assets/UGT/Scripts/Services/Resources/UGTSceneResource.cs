using System.Threading.Tasks;
using UGT.Services.Resources.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace UGT.Services.Resources
{
    public class UGTSceneResource : UGTIResource
    {
        private SceneInstance _sceneInstance;

        private readonly string _path;

        public UGTSceneResource(string path)
        {
            _path = path;
        }

        public async Task Load()
        {
            _sceneInstance = await Addressables.LoadSceneAsync(_path, UnityEngine.SceneManagement.LoadSceneMode.Additive).Task;
            _sceneInstance.ActivateAsync();
        }

        public async Task Unload()
        {
            await Addressables.UnloadSceneAsync(_sceneInstance).Task;
        }
    }
}
