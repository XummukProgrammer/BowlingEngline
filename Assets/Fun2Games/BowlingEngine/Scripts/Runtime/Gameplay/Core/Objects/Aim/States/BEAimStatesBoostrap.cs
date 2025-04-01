using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEAimStates _states;

        public BEAimStatesBoostrap(BEAimStates states)
        {
            _states = states;
        }

        public void Enter()
        {
            _states.EnterState<BEAimStatesIdentifyDir>();
        }

        public void Exit()
        {
        }
    }
}
