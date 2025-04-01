using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallView : MonoBehaviour
    {
        public BEBallFacade Facade => _facade;

        public Vector3 LinearVelocity
        {
            get => _rigidBody.linearVelocity;
            set => _rigidBody.linearVelocity = value;
        }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Quaternion
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        public SplineComputer Follow
        {
            get => _follower.spline;
            set
            {
                _follower.spline = value;
                _follower.follow = true;
                _follower.followSpeed = 3;
            }
        }

        [SerializeField]
        private SplineFollower _follower;

        private BEBallFacade _facade;
        private Rigidbody _rigidBody;

        [Inject]
        public void Construct(BEBallFacade facade)
        {
            _facade = facade;
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
    }
}
