using System.Threading.Tasks;
using UnityGameTemplate.Resources.Services;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;
using UnityGameTemplate.UI.Windows.Services;
using Zenject;

namespace UnityGameTemplate.Common.States
{
    public class UGTStatesLoad<TMachine, TLoader, TNextState>
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
        where TMachine : UGTBaseStatesService
        where TLoader : UGTResourcesLoaderService
        where TNextState : UGTIExitableState
    {
        private bool _isLoadStarted = false;

        protected readonly TMachine _statesService;

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
            TryStartLoad();
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            if (!_isLoadStarted)
            {
                TryStartLoad();
            }
        }

        private async Task LoadResources()
        {
            _isLoadStarted = true;

            OnBeforeLoad();

            await _resourcesLoaderService.Load();

            OnAfterLoad();

            _statesService.EnterState<TNextState>();
        }

        protected virtual void OnBeforeLoad()
        {
            _windowContainerService.ShowWindow("LoadWindow");
        }

        protected virtual bool CanStartLoad()
        {
            return true;
        }

        protected virtual void OnAfterLoad()
        {
            _windowContainerService.CloseWindow("LoadWindow");
        }

        private void TryStartLoad()
        {
            if (CanStartLoad())
            {
                _ = LoadResources();
            }
        }
    }
}
