using BowlingEngine.Services.StatesMachine.Interfaces;
using System.Collections.Generic;
using Zenject;

namespace BowlingEngine.Services.StatesMachine
{
    public abstract class StatesMachineService : IInitializable, ITickable
    {
        private Dictionary<string, IStatesMachineExitableState> _states = new();
        private IStatesMachineExitableState _currentState;
        private IStatesMachineExitableState _nextState;

        public void Initialize()
        {
            foreach (var state in GetStates())
                _states.Add(state.GetType().Name, state);

            var defaultState = GetDefaultState();
            if (defaultState != null && _states.ContainsKey(defaultState.GetType().Name))
                _nextState = defaultState;
        }

        public void Tick()
        {
            if (_nextState != null)
            {
                _currentState?.Exit();

                _currentState = _nextState;
                _nextState = null;

                if (_currentState is IStatesMachineEnterableState enterableState)
                    enterableState.Enter();
            }
        }

        public T GetState<T>() where T : IStatesMachineExitableState
        {
            if (_states.TryGetValue(typeof(T).Name, out var state))
                return (T)state;
            return default;
        }

        public void ChangeState<T>() where T : IStatesMachineExitableState
        {
            if (_nextState != null)
                return;

            var nextState = GetState<T>();
            if (nextState != null)
                _nextState = nextState;
        }

        protected abstract List<IStatesMachineExitableState> GetStates();
        protected abstract IStatesMachineExitableState GetDefaultState();
    }
}
