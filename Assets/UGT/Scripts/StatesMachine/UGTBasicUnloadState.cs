using UGT.Common.States;
using UGT.Services.Resources;

namespace UGT.StatesMachine
{
    public class UGTBasicUnloadState : UGTUnloadState
    {
        public UGTBasicUnloadState(UGTResourcesLoaderService resourcesLoaderService) 
            : base(resourcesLoaderService)
        {
        }

        protected override void OnUnloaded()
        {
        }
    }
}
