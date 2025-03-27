using System.Threading.Tasks;
using UGT.Services.Resources;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.Common.States
{
    public abstract class UGTLoadState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTResourcesLoaderService _resourcesLoaderService;

        public UGTLoadState(UGTResourcesLoaderService resourcesLoaderService)
        {
            _resourcesLoaderService = resourcesLoaderService;
        }

        public void Enter()
        {
            Debug.Log("UGTLoadState.Enter");

            _ = Load();
        }

        public void Exit()
        {
            Debug.Log("UGTLoadState.Exit");
        }

        private async Task Load()
        {
            await _resourcesLoaderService.Load();

            OnLoaded();
        }

        protected abstract void OnLoaded();
    }
}
