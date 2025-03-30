using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBallFollowerInitializer : MonoBehaviour
    {
        private SplineFollower _follower;

        [Inject]
        public void Construct(SplineFollower follower)
        {
            _follower = follower;
        }

        private void Awake()
        {
            _follower.followSpeed = 5;
        }
    }
}
