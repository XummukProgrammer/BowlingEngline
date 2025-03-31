using BowlingEngine.Gameplay.Core.Signals;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesMove
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly SignalBus _signalBus;

        public BEBallStatesMove(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Enter()
        {
            Debug.Log("BEBallStatesMove.Enter");
        }

        public void Exit()
        {
            Debug.Log("BEBallStatesMove.Exit");
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _signalBus.Fire<BEBallWorkedSignal>();
            }
        }
    }
}
