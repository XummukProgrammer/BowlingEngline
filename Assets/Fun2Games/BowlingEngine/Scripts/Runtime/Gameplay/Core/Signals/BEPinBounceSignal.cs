namespace BowlingEngine.Gameplay.Core.Signals
{
    public class BEPinBounceSignal
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public BEPinBounceSignal(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
