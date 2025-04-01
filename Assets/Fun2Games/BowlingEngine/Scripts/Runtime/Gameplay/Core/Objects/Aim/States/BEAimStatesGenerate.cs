using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesGenerate
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEAimStates _states;

        public BEAimStatesGenerate(BEAimStates states)
        {
            _states = states;
        }

        public void Enter()
        {
            _states.EnterState<BEAimStatesStay>();
        }

        public void Exit()
        {
        }
    }
}
