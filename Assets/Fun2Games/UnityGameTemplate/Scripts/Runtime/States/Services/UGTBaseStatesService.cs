using System;
using System.Collections.Generic;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace UnityGameTemplate.States.Services
{
    public abstract class UGTBaseStatesService : IInitializable, ITickable
    {
        protected UGTStateFactory Factory { get; }

        protected abstract IEnumerable<UGTIExitableState> States { get; }
        protected abstract UGTIExitableState DefaultState { get; }

        private Dictionary<Type, UGTIExitableState> _states = new();
        private UGTIExitableState _currentState;
        private UGTIExitableState _nextState;

        public UGTBaseStatesService(UGTStateFactory factory)
        {
            Factory = factory;
        }

        public void Initialize()
        {
            foreach (var state in States)
            {
                _states.Add(state.GetType(), state);
            }

            _currentState = DefaultState;

            TryEnterCurrentState();
        }

        public void Tick()
        {
            if (_nextState != null)
            {
                if (_currentState != null)
                {
                    _currentState.Exit();
                }

                _currentState = _nextState;
                _nextState = null;

                TryEnterCurrentState();
                return;
            }

            TryTickCurrentState();
        }

        public void EnterState<T>() where T : UGTIExitableState
        {
            _nextState = GetState<T>();
        }

        private UGTIExitableState GetState<T>() where T : UGTIExitableState
        {
            if (_states.TryGetValue(typeof(T), out var state))
            {
                return state;
            }
            return null;
        }

        private void TryEnterCurrentState()
        {
            if (_currentState is UGTIEnterableState enterableState)
            {
                enterableState.Enter();
            }
        }

        private void TryTickCurrentState()
        {
            if (_currentState is ITickable tickableState)
            {
                tickableState.Tick();
            }
        }
    }
}
