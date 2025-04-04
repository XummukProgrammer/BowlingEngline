using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityGameTemplate.Resources.Interfaces;

namespace UnityGameTemplate.Resources.Implementation
{
    public class UGTCommonResource<T> : UGTIResource
    {
        public string ID { get; private set; }
        public string Path { get; private set; }
        public T Result => _handler.Result;

        private AsyncOperationHandle<T> _handler;

        public UGTCommonResource(string id, string path)
        {
            ID = id;
            Path = path;
        }

        public async Task Load()
        {
            _handler = Addressables.LoadAssetAsync<T>(Path);

            await _handler.Task;

            if (_handler.Status == AsyncOperationStatus.Succeeded)
            {
                await OnLoaded();
            }
            else
            {
                await OnFailed();
            }
        }

        public async Task Unload()
        {
            await Task.Run(async () =>
            {
                await OnUnloaded();
                Addressables.Release(_handler);
            });
        }

        protected virtual async Task OnLoaded() { }
        protected virtual async Task OnFailed() { }
        protected virtual async Task OnUnloaded() { }
    }
}
