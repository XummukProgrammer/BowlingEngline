using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallFacade : MonoBehaviour
    {
        public event Action SplineStarted;
        public event Action SplineEnded;

        public BEBallStates States => _states;

        private BEBallView _view;
        private BEBallStates _states;

        [Inject]
        public void Construct(
            BEBallView view, 
            BEBallStates states)
        {
            _view = view;
            _states = states;
        }

        private void OnEnable()
        {
            _view.Follower.onBeginningReached += OnSplineStarted;
            _view.Follower.onEndReached += OnSplineEnded;
        }

        private void OnDisable()
        {
            _view.Follower.onBeginningReached -= OnSplineStarted;
            _view.Follower.onEndReached -= OnSplineEnded;
        }

        private void OnSplineStarted(double percent)
        {
            SplineStarted?.Invoke();
        }

        private void OnSplineEnded(double percent)
        {
            SplineEnded?.Invoke();
        }
    }
}
