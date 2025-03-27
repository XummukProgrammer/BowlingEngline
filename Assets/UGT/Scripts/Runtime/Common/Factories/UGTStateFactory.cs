using UGT.Services.StatesMachine.Interfaces;
using Zenject;

namespace UGT.Common.Factories
{
    public class UGTStateFactory
    {
        private readonly DiContainer _diContainer;

        public UGTStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create<T>() where T : UGTIExitableState
        {
            return _diContainer.Resolve<T>();
        }
    }
}
