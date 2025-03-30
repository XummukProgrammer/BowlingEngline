using Zenject;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinPhysicsInitializer : IInitializable
    {
        private BEPinView _view;

        public BEPinPhysicsInitializer(BEPinView view)
        {
            _view = view;
        }

        public void Initialize()
        {
            _view.Mass = 0.4f;
        }
    }
}
