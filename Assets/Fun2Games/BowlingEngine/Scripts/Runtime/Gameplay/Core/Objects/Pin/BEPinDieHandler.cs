namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinDieHandler
    {
        private readonly BEPinFacade _facade;

        public BEPinDieHandler(BEPinFacade facade)
        {
            _facade = facade;
        }

        public void Die()
        {
            _facade.Dispose();
        }
    }
}
