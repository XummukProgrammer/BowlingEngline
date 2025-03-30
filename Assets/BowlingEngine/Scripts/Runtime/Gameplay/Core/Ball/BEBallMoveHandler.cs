using BowlingEngine.Gameplay.Core.Services.Input.Interfaces;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallMoveHandler : MonoBehaviour
    {
        private BEBallView _view;
        private BEBallState _state;
        private BEIInput _input;

        [Inject]
        public void Construct(
            BEBallView view, 
            BEBallState state,
            BEIInput input)
        {
            _view = view;
            _state = state;
            _input = input;
        }

        private void Update()
        {
            if (_state.StateType == BEBallStateType.Move)
            {
                _view.HorizontalDiff = _input.HorizontalDiff;
            }
        }
    }
}
