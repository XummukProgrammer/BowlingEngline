using BowlingEngine.Gameplay.Core.Objects.Pin;
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

        public int Health
        {
            get => _healthData.Value;
            set => _healthData.Value = value;
        }

        private BEBallView _view;
        private BEBallStates _states;
        private BEHealthData _healthData;

        [Inject]
        public void Construct(
            BEBallView view, 
            BEBallStates states,
            BEHealthData healthData)
        {
            _view = view;
            _states = states;
            _healthData = healthData;
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
