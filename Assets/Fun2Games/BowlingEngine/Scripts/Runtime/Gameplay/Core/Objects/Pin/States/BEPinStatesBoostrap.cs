using System.Threading.Tasks;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Pin.States
{
    public class BEPinStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEPinView _view;

        public BEPinStatesBoostrap(BEPinView view)
        {
            _view = view;
        }

        public void Enter()
        {
            _view.Facade.States.EnterState<BEPinStatesDisable>();
        }

        public void Exit()
        {
        }
    }
}
