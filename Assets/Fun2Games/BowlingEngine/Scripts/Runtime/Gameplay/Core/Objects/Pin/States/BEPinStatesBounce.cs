using System.Threading.Tasks;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Pin.States
{
    public class BEPinStatesBounce
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BEPinDieHandler _dieHandler;

        public BEPinStatesBounce(BEPinDieHandler dieHandler)
        {
            _dieHandler = dieHandler;
        }

        public void Enter()
        {
            _ = DoDie();
        }

        public void Exit()
        {
        }

        public async Task DoDie()
        {
            await Task.Delay(1000);

            _dieHandler.Die();
        }
    }
}
