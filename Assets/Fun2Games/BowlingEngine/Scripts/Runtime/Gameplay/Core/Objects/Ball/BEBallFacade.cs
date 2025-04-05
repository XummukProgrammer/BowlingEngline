using BowlingEngine.Gameplay.Core.Objects.Data;
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

        public string ClassID { get; set; }

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

        public float ForwardForceForPin
        {
            get => _tunables.ForwardForceForPin;
            set => _tunables.ForwardForceForPin = value;
        }

        public float UpForceForPin
        {
            get => _tunables.UpForceForPin;
            set => _tunables.UpForceForPin = value;
        }

        public float DirForceForPin
        {
            get => _tunables.DirForceForPin;
            set => _tunables.DirForceForPin = value;
        }

        public float TorsionFactor
        {
            get; set;
        } = 5;

        private BEBallView _view;
        private BEBallStates _states;
        private BEHealthData _healthData;
        private BESpeedData _speedData;
        private BEBallTunables _tunables;

        [Inject]
        public void Construct(
            BEBallView view, 
            BEBallStates states,
            BEHealthData healthData,
            BESpeedData speedData,
            BEBallTunables tunables)
        {
            _view = view;
            _states = states;
            _healthData = healthData;
            _speedData = speedData;
            _tunables = tunables;
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
