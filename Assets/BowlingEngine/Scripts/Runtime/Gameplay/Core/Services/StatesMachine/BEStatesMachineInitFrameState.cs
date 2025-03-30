using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineInitFrameState
        : UGTIExitableState
        , UGTIEnterableState
    {
        public void Enter()
        {
            Debug.Log("BEStatesMachineInitFrameState.Enter");
        }

        public void Exit()
        {
            Debug.Log("BEStatesMachineInitFrameState.Exit");
        }
    }
}
