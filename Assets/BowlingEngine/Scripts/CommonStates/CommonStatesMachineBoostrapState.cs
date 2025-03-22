using BowlingEngine.Services.StatesMachine.Interfaces;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineBoostrapState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private readonly CommonStatesMachineService _statesMachineService;

        public CommonStatesMachineBoostrapState(CommonStatesMachineService statesMachineService)
        {
            _statesMachineService = statesMachineService;
        }

        public void Enter()
        {
            _statesMachineService.ChangeState<CommonStatesMachineLoadCoreGameplayState>();
        }

        public void Exit()
        {
        }
    }
}
