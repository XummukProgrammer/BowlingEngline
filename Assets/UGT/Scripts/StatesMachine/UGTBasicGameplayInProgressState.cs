using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;

namespace UGT.StatesMachine
{
    public class UGTBasicGameplayInProgressState
        : UGTIExitableState
        , UGTIEnterableState
    {
        public void Enter()
        {
            Debug.Log("UGTBasicGameplayInProgressState.Enter");
        }

        public void Exit()
        {
            Debug.Log("UGTBasicGameplayInProgressState.Exit");
        }
    }
}
