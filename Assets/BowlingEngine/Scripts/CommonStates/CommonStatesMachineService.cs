using BowlingEngine.Infrastructure.Factories;
using BowlingEngine.Services.StatesMachine;
using BowlingEngine.Services.StatesMachine.Interfaces;
using System.Collections.Generic;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineService : StatesMachineService
    {
        private readonly StateFactory _stateFactory;

        public CommonStatesMachineService(StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        protected override List<IStatesMachineExitableState> GetStates()
        {
            return new() 
            {
                _stateFactory.Create<CommonStatesMachineBoostrapState>(),
                _stateFactory.Create<CommonStatesMachineLoadMetaGameplayState>(),
                _stateFactory.Create<CommonStatesMachineLoadCoreGameplayState>(),
                _stateFactory.Create<CommonStatesMachineMetaGameplayState>(),
                _stateFactory.Create<CommonStatesMachineCoreGameplayState>()
            };
        }

        protected override IStatesMachineExitableState GetDefaultState()
        {
            return _stateFactory.Create<CommonStatesMachineBoostrapState>();
        }
    }
}
