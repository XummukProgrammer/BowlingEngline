using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Aim.States
{
    public class BEAimStatesDisable
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEAimView _view;

        public BEAimStatesDisable(BEAimView view)
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
