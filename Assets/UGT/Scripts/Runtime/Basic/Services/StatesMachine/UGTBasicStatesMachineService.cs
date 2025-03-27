using System.Collections.Generic;
using UGT.Common.Factories;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicStatesMachineService : UGTStatesMachineService
    {
        public UGTBasicStatesMachineService(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> AddedStates
        {
            get
            {
                return new List<UGTIExitableState>
                {
                    Factory.Create<UGTBasicBoostrapState>(),
                    Factory.Create<UGTBasicGameplayLoadState>(),
                    Factory.Create<UGTBasicGameplayInProgressState>(),
                    Factory.Create<UGTBasicGameplayUnloadState>()
                };
            }
        }

        protected override UGTIExitableState DefaultState
        {
            get
            {
                return Factory.Create<UGTBasicBoostrapState>();
            }
        }
    }
}
