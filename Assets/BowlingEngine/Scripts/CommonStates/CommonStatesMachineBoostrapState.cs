using BowlingEngine.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace BowlingEngine.CommonStates
{
    public class CommonStatesMachineBoostrapState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        public void Enter()
        {
            Debug.Log("CommonStatesMachineBoostrapState:Enter");
        }

        public void Exit()
        {
        }
    }
}
