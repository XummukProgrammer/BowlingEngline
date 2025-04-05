using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEAimView _view;
        private readonly BEAimStates _states;

        public BEAimStatesBoostrap(
            BEAimView view, 
            BEAimStates states)
        {
            _view = view;
            _states = states;
        }

        public void Enter()
        {
            _view.LastPointXPosition = 0;

            _states.EnterState<BEAimStatesIdentifyDir>();
        }

        public void Exit()
        {
        }
    }
}
