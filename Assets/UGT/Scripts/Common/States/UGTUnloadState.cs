using System.Threading.Tasks;
using UGT.Services.Resources;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Common.States
{
    public abstract class UGTUnloadState
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTResourcesLoaderService _resourcesLoaderService;

        public UGTUnloadState(UGTResourcesLoaderService resourcesLoaderService)
        {
            _resourcesLoaderService = resourcesLoaderService;
        }

        public void Enter()
        {
            Debug.Log("UGTUnloadState.Enter");

            _ = Unload();
        }

        public void Exit()
        {
            Debug.Log("UGTUnloadState.Exit");
        }

        private async Task Unload()
        {
            await _resourcesLoaderService.Unload();

            OnUnloaded();
        }

        protected abstract void OnUnloaded();
    }
}
