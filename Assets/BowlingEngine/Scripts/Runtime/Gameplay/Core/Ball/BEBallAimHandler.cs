using BowlingEngine.Gameplay.Core.Aim;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallAimHandler : MonoBehaviour
    {
        private BEAimView _aimView;

        [Inject]
        public void Construct(BEAimView aimView)
        {
            _aimView = aimView;
        }

        private void Update()
        {
            _aimView.Position = transform.position;
        }
    }
}
