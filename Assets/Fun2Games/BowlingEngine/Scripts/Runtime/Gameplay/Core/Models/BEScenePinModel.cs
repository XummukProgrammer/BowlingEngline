namespace BowlingEngine.Gameplay.Core.Models
{
    public class BEScenePinModel
    {
        public string ID { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public BEScenePinModel(string iD, int x, int y)
        {
            ID = iD;
            X = x;
            Y = y;
        }
    }
}
