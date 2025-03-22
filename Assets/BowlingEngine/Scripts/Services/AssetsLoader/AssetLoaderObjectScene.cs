using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace BowlingEngine.Services.AssetsLoader
{
    public class AssetLoaderObjectScene : IAssetLoaderObject
    {
        private SceneInstance _sceneInstance;

        public async Task Load(string path)
        {
            var handle = Addressables.LoadSceneAsync(
                path,
                LoadSceneMode.Additive);

            _sceneInstance = await handle.Task;

            _sceneInstance.ActivateAsync();
        }

        public async Task Unload()
        {
            await Addressables.UnloadSceneAsync(_sceneInstance).Task;
        }
    }
}
