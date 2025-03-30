using BowlingEngine.Gameplay.Core.Aim;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallAimHandler : MonoBehaviour
    {
        private BEAimView _aimView;
        private BEBallState _state;

        [Inject]
        public void Construct(
            BEAimView aimView,
            BEBallState state)
        {
            _aimView = aimView;
            _state = state;
        }

        private void Update()
        {
            if (_state.StateType == BEBallStateType.Move)
            {
                _aimView.Position = transform.position;
            }
        }
    }
}
