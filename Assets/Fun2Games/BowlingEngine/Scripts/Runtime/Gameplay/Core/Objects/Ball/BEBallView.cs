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

        public Transform SkinTransform { get; private set; }

        public Quaternion SkinQuaternion
        {
            get => SkinTransform.rotation;
            set => SkinTransform.rotation = value;
        }

        [SerializeField]
        private SplineFollower _follower;

        [SerializeField]
        private SplineUser _splineUser;

        [SerializeField]
        private Transform _skinsTransform;

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

            _splineUser.spline = spline;
        }

        public void Unfollow()
        {
            _follower.spline = null;
            _follower.follow = false;

            _splineUser.spline = null;
        }

        public void SetSkin(string skinID)
        {
            if (SkinTransform != null)
            {
                SkinTransform.rotation = Quaternion.identity;
            }

            if (_skinsTransform != null)
            {
                for (int i = 0; i < _skinsTransform.childCount; i++)
                {
                    _skinsTransform.GetChild(i).gameObject.SetActive(false);
                }

                SkinTransform = _skinsTransform.Find(skinID);
                if (SkinTransform != null)
                {
                    SkinTransform.gameObject.SetActive(true);
                }
            }
        }
    }
}
