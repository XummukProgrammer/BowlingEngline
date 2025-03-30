namespace BowlingEngine.Gameplay.Core.Pin
{
    public enum BEPinStateType
    {
        Stay,
        Bounce
    }

    public class BEPinState
    {
        public BEPinStateType StateType {  get; set; }
    }
}
