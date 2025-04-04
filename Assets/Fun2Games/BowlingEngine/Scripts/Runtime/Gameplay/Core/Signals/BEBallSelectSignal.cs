namespace BowlingEngine.Gameplay.Core.Signals
{
    public class BEBallSelectSignal
    {
        public string BallID { get; private set; }

        public BEBallSelectSignal(string ballID)
        {
            BallID = ballID;
        }
    }
}
