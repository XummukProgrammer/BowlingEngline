using BowlingEngine.Services.StatesMachine.Interfaces;
using Zenject;

namespace BowlingEngine.Infrastructure.Factories
{
    public class StateFactory
    {
        private readonly DiContainer _diContainer;

        public StateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create<T>() where T : IStatesMachineExitableState
        {
            return _diContainer.Resolve<T>();
        }
    }
}
