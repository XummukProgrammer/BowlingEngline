using BowlingEngine.Gameplay.Core.Objects.Spawns;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private BEBallView _view;
        private BEBallSpawn _spawn;

        public BEBallStatesBoostrap(
            BEBallView view, 
            BEBallSpawn spawn)
        {
            _view = view;
            _spawn = spawn;
        }

        public void Enter()
        {
            _view.Position = _spawn.Position;
            _view.Quaternion = _spawn.Quaternion;

            _view.Facade.States.EnterState<BEBallStatesMove>();
        }

        public void Exit()
        {
        }
    }
}
