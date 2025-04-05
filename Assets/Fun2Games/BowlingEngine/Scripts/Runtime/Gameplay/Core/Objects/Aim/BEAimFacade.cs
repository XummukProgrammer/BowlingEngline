using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Aim
{
    public class BEAimFacade : MonoBehaviour
    {
        public BEAimStates States { get; private set; }

        [Inject]
        public void Construct(BEAimStates states)
        {
            States = states;
        }

        public void OnTrigger1Activated(SplineUser user)
        {
            Debug.Log("OnTrigger1Activated");
        }
    }
}
