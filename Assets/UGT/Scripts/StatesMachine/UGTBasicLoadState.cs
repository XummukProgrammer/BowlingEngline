using UGT.Common.States;
using UGT.Services.Resources;

namespace UGT.StatesMachine
{
    public class UGTBasicLoadState : UGTLoadState
    {
        public UGTBasicLoadState(UGTResourcesLoaderService resourcesLoaderService) 
            : base(resourcesLoaderService)
        {
        }

        protected override void OnLoaded()
        {
        }
    }
}
