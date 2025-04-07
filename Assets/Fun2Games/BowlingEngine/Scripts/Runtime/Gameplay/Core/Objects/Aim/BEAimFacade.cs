using BowlingEngine.Gameplay.Core.Signals;
using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Aim
{
    public class BEAimFacade : MonoBehaviour
    {
        private SignalBus _signalBus;

        public BEAimStates States { get; private set; }

        [Inject]
        public void Construct(
            BEAimStates states,
            SignalBus signalBus)
        {
            States = states;

            _signalBus = signalBus;
        }

        public void OnTriggerActivated(SplineUser user)
        {
            _signalBus.Fire(new BEUserTriggeredSignal(user));
        }
    }
}
