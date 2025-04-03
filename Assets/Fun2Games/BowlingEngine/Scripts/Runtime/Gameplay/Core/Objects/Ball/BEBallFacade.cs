using BowlingEngine.Gameplay.Core.Objects.Data;
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

        public int MaxHealth
        {
            get => _healthData.MaxValue;
            set => _healthData.MaxValue = value;
        }

        public float Speed
        {
            get => _speedData.Value;
            set => _speedData.Value = value;
        }

        public float MaxSpeed
        {
            get => _speedData.MaxValue;
            set => _speedData.MaxValue = value;
        }

        private BEBallView _view;
        private BEBallStates _states;
        private BEHealthData _healthData;
        private BESpeedData _speedData;

        [Inject]
        public void Construct(
            BEBallView view, 
            BEBallStates states,
            BEHealthData healthData,
            BESpeedData speedData)
        {
            _view = view;
            _states = states;
            _healthData = healthData;
            _speedData = speedData;
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
