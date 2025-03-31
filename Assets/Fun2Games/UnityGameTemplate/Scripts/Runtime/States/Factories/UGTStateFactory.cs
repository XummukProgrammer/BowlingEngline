using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace UnityGameTemplate.States.Factories
{
    public class UGTStateFactory
    {
        private readonly DiContainer _diContainer;

        public UGTStateFactory(DiContainer container)
        {
            _diContainer = container;
        }

        public T Create<T>() where T : UGTIExitableState
        {
            return _diContainer.Resolve<T>();
        }
    }
}
