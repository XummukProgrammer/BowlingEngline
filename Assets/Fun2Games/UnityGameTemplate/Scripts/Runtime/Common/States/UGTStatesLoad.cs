using System.Threading.Tasks;
using UnityGameTemplate.Resources.Services;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;
using UnityGameTemplate.UI.Windows.Services;

namespace UnityGameTemplate.Common.States
{
    public class UGTStatesLoad<TMachine, TLoader, TNextState>
        : UGTIExitableState
        , UGTIEnterableState
        where TMachine : UGTBaseStatesService
        where TLoader : UGTResourcesLoaderService
        where TNextState : UGTIExitableState
    {
        private readonly TMachine _statesService;
        private readonly TLoader _resourcesLoaderService;
        private readonly UGTWindowContainerService _windowContainerService;

        public UGTStatesLoad(
            TMachine statesService,
            TLoader resourcesLoaderService,
            UGTWindowContainerService windowContainerService)
        {
            _statesService = statesService;
            _resourcesLoaderService = resourcesLoaderService;
            _windowContainerService = windowContainerService;
        }

        public void Enter()
        {
            _ = LoadResources();
        }

        public void Exit()
        {
        }

        private async Task LoadResources()
        {
            OnBeforeLoad();

            await _resourcesLoaderService.Load();

            OnAfterLoad();

            _statesService.EnterState<TNextState>();
        }

        protected virtual void OnBeforeLoad()
        {
            _windowContainerService.ShowWindow("LoadWindow");
        }

        protected virtual void OnAfterLoad()
        {
            _windowContainerService.CloseWindow("LoadWindow");
        }
    }
}
