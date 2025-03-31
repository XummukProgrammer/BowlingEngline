using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesDisable
        : UGTIExitableState
        , UGTIEnterableState
    {
        public void Enter()
        {
            Application.Quit();
        }

        public void Exit()
        {
        }
    }
}
