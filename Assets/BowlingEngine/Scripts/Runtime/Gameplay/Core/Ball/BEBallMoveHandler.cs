using BowlingEngine.Gameplay.Core.Services.Input.Interfaces;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallMoveHandler : MonoBehaviour
    {
        private BEBallView _view;
        private BEIInput _input;

        [Inject]
        public void Construct(
            BEBallView view, 
            BEIInput input)
        {
            _view = view;
            _input = input;
        }

        private void Update()
        {
            _view.HorizontalDiff = _input.HorizontalDiff;
        }
    }
}
