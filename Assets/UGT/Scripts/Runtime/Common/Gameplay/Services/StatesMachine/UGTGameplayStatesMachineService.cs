using System.Collections.Generic;
using UGT.Common.Factories;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;

namespace UGT.Common.Gameplay.Services.StatesMachine
{
    public class UGTGameplayStatesMachineService : UGTStatesMachineService
    {
        public UGTGameplayStatesMachineService(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> AddedStates
        {
            get
            {
                return new List<UGTIExitableState>
                {
                    Factory.Create<UGTGameplayBoostrapState>(),
                    Factory.Create<UGTGameplayLoadState>(),
                    Factory.Create<UGTGameplayInProgressState>(),
                    Factory.Create<UGTGameplayUnloadState>()
                };
            }
        }

        protected override UGTIExitableState DefaultState => Factory.Create<UGTGameplayBoostrapState>();
    }
}
