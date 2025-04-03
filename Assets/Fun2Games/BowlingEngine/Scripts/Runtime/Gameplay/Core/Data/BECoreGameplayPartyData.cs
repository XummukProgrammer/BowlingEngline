using BowlingEngine.Gameplay.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace BowlingEngine.Gameplay.Core.Data
{
    public class BECoreGameplayPartyData
    {
        public int FramesCount { get; set; }
        public int Score { get; set; }
        public IEnumerable<BEScenePinModel> Pins => _pins;

        private List<BEScenePinModel> _pins = new();

        public void AddPin(string id, int x, int y)
        {
            _pins.Add(new BEScenePinModel(id, x, y));
        }

        public void RemovePin(int x, int y)
        {
            var pin = _pins.FirstOrDefault(p => p.X == x && p.Y == y);
            if (pin != null)
            {
                _pins.Remove(pin);
            }
        }

        public void ClearPins()
        {
            _pins.Clear();
        }
    }
}
