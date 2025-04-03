using BowlingEngine.Gameplay.Core.Models;
using System.Collections.Generic;

namespace BowlingEngine.Gameplay.Core.Data
{
    public class BECoreGameplayPartyData
    {
        public int FramesCount { get; set; }
        public int Score { get; set; }

        public BEPartyModel PartyModel { get; set; }

        public List<(int, int)> RemovedPins { get; set; } = new();
    }
}
