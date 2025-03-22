using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace BowlingEngine.Services.AssetsLoader
{
    public class AssetLoaderObjectDynamic<T> : IAssetLoaderObject
    {
        public T Result => _handle.Result;

        private AsyncOperationHandle<T> _handle;

        public async Task Load(string path)
        {
            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(path);
            await handle.Task;
            if (handle.Status == AsyncOperationStatus.Succeeded)
                _handle = handle;
        }

        public async Task Unload()
        {
            Addressables.Release(_handle);
        }
    }
}
