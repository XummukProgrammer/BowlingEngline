using Dreamteck.Splines;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallView : MonoBehaviour
    {
        [Inject]
        public BEBallFacade Facade { get; set; }

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

        public bool IsKinematic
        {
            get => _rigidBody.isKinematic;
            set => _rigidBody.isKinematic = value;
        }

        public Collider Collider => GetComponentInChildren<Collider>();

        public SplineFollower Follower => _follower;

        public float FollowerSpeed
        {
            get => _follower.followSpeed;
            set => _follower.followSpeed = value;
        }

        [SerializeField]
        private SplineFollower _follower;

        private Rigidbody _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void SetFollow(SplineComputer spline)
        {
            _follower.SetDistance(0);

            _follower.spline = spline;
            _follower.follow = true;
        }

        public void Unfollow()
        {
            _follower.spline = null;
            _follower.follow = false;
        }
    }
}
