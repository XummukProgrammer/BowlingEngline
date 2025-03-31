using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesMove
        : UGTIExitableState
        , UGTIEnterableState
    {
        public void Enter()
        {
            Debug.Log("BEBallStatesMove.Enter");
        }

        public void Exit()
        {
            Debug.Log("BEBallStatesMove.Exit");
        }
    }
}
