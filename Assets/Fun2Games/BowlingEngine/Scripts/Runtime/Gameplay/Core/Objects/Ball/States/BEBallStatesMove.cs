using BowlingEngine.Gameplay.Core.Services.Input;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesMove
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly BEBallView _view;
        private readonly BEIInput _input;

        public BEBallStatesMove(
            BEBallView view,
            BEIInput input)
        {
            _view = view;
            _input = input;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            if (_input.Drop)
            {
                _view.Facade.States.EnterState<BEBallStatesDrop>();
                return;
            }

            _view.LinearVelocity = _input.Velocity;
        }
    }
}
