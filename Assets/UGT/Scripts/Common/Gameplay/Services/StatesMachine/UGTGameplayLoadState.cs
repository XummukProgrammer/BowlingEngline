using UGT.Common.States;
using UGT.Services.Resources;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTGameplayLoadState : UGTLoadState
    {
        public UGTGameplayLoadState(UGTResourcesLoaderService resourcesLoaderService) 
            : base(resourcesLoaderService)
        {
        }

        protected override void OnLoaded()
        {
        }
    }
}
