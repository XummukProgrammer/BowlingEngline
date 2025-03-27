using System.Collections.Generic;
using UGT.Infrastructure.Factories;
using UGT.Services.StatesMachine.Interfaces;
using Zenject;

namespace UGT.Services.StatesMachine
{
    public abstract class UGTStatesMachineService 
        : IInitializable
        , ITickable
    {
        public UGTStateFactory Factory { get; private set; }

        protected abstract IEnumerable<UGTIExitableState> AddedStates { get; }
        protected abstract UGTIExitableState DefaultState { get; }

        private Dictionary<string, UGTIExitableState> _states = new();
        private UGTIExitableState _currentState;
        private UGTIExitableState _nextState;

        public UGTStatesMachineService(UGTStateFactory factory)
        {
            Factory = factory;
        }

        public void Initialize()
        {
            foreach (var state in AddedStates)
                _states.Add(state.GetType().Name, state);

            _currentState = DefaultState;

            TryEnterCurrentState();
        }

        public void Tick()
        {
            if (_nextState != null)
            {
                _currentState?.Exit();

                _currentState = _nextState;
                _nextState = null;

                TryEnterCurrentState();
            }
        }

        private void TryEnterCurrentState()
        {
            if (_currentState != null && _currentState is UGTIEnterableState enterableState)
                enterableState.Enter();
        }
    }
}
