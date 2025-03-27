using UGT.Common.States;
using UGT.Services.Resources;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTGameplayUnloadState : UGTUnloadState
    {
        public UGTGameplayUnloadState(UGTResourcesLoaderService resourcesLoaderService) 
            : base(resourcesLoaderService)
        {
        }

        protected override void OnUnloaded()
        {
        }
    }
}
