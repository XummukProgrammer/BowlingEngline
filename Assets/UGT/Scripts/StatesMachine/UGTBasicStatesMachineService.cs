using System.Collections.Generic;
using UGT.Infrastructure.Factories;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;

namespace UGT.StatesMachine
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
                    Factory.Create<UGTBasicBoostrapState>()
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
