using Dreamteck.Splines;

namespace BowlingEngine.Gameplay.Core.Signals
{
    public class BEUserTriggeredSignal
    {
        public SplineUser User { get; private set; }

        public BEUserTriggeredSignal(SplineUser user)
        {
            User = user;
        }
    }
}
