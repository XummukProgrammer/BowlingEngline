using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallView : MonoBehaviour
    {
        public BEBallFacade Facade => _facade;

        public Vector3 AngularVelocity
        {
            get => _rigidBody.angularVelocity;
            set => _rigidBody.angularVelocity = value;
        }

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
