using BowlingEngine.Gameplay.Core.Aim;
using BowlingEngine.Gameplay.Core.Services.Input.Interfaces;
using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallDropHandler : MonoBehaviour
    {
        private BEBallView _view;
        private BEBallState _state;
        private BEIInput _input;
        private BEAimView _aimView;
        private SplineFollower _follower;

        [Inject]
        public void Construct(
            BEBallView view,
            BEBallState state,
            BEIInput input,
            BEAimView aimView,
            SplineFollower follower)
        {
            _view = view;
            _state = state;
            _input = input;
            _aimView = aimView;
            _follower = follower;
        }

        private void Update()
        {
            if (_state.StateType == BEBallStateType.Move)
            {
                if (_input.Drop)
                {
                    _state.StateType = BEBallStateType.Drop;

                    _follower.spline = _aimView.SplineComputer;
                    _follower.follow = true;
                }
            }
            else if (_state.StateType != BEBallStateType.Drop)
            {

            }
        }
    }
}
