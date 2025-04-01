using System.Collections.Generic;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinRegistry
    {
        public IEnumerable<BEPinFacade> Pins => _pins;

        private List<BEPinFacade> _pins = new();

        public void AddPin(BEPinFacade pin)
        {
            _pins.Add(pin);
        }

        public void RemovePin(BEPinFacade pin)
        {
            _pins.Remove(pin);
        }
    }
}
