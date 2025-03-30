using System.Collections.Generic;
using UGT.Common.Factories;
using UGT.Services.StatesMachine;
using UGT.Services.StatesMachine.Interfaces;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineService : UGTStatesMachineService
    {
        public BEStatesMachineService(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> AddedStates
        {
            get
            {
                return new List<UGTIExitableState>
                {
                    Factory.Create<BEStatesMachineBoostrapState>(),
                    Factory.Create<BEStatesMachineLoadState>(),
                    Factory.Create<BEStatesMachineInitFrameState>(),
                    Factory.Create<BEStatesMachineStepFrameState>(),
                    Factory.Create<BEStatesMachineUnloadState>()
                };
            }
        }

        protected override UGTIExitableState DefaultState => Factory.Create<BEStatesMachineBoostrapState>();
    }
}
