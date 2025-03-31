using System.Threading.Tasks;
using UnityGameTemplate.Resources.Services;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

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

        public UGTStatesLoad(
            TMachine statesService,
            TLoader resourcesLoaderService)
        {
            _statesService = statesService;
            _resourcesLoaderService = resourcesLoaderService;
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
            await _resourcesLoaderService.Load();

            _statesService.EnterState<TNextState>();
        }
    }
}
