using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallFacade : MonoBehaviour
    {
        public BEBallStates States => _states;

        private BEBallStates _states;

        [Inject]
        public void Construct(BEBallStates states)
        {
            _states = states;
        }
    }
}
