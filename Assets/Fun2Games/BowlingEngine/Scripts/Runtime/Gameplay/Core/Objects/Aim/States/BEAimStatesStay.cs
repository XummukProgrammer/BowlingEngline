using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesStay
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEAimView _view;

        public BEAimStatesStay(BEAimView view)
        {
            _view = view;
        }

        public void Enter()
        {
            _view.EnableRenderer = false;
        }

        public void Exit()
        {
        }
    }
}
