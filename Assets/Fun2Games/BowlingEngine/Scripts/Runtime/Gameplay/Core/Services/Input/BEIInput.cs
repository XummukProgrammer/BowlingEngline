using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Services.Input
{
    public interface BEIInput
    {
        public bool Enable { get; set; }

        public Vector3 Velocity { get; }

        public bool Drop { get; }
    }
}
