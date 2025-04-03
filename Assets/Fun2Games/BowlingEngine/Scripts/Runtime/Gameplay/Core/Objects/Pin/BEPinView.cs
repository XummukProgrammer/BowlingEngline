using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinView : MonoBehaviour
    {
        [Inject]
        public BEPinFacade Facade { get; set; }

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

        public Collider Collider => GetComponentInChildren<Collider>();

        public float MaterialBounce
        {
            set
            {
                var collider = Collider;
                collider.material.bounciness = value;
                collider.material.bounceCombine = value > 0f ? PhysicsMaterialCombine.Maximum : PhysicsMaterialCombine.Average;
            }
        }

        public Vector3 LinearVelocity
        {
            get => _rigidBody.linearVelocity;
            set => _rigidBody.linearVelocity = value;
        }

        public Vector3 AngularVelocity
        {
            get => _rigidBody.angularVelocity;
            set => _rigidBody.angularVelocity = value;
        }

        public bool IsKinematic
        {
            get => _rigidBody.isKinematic;
            set => _rigidBody.isKinematic = value;
        }

        public Vector3 Forward => transform.forward;
        public Vector3 Back => -Forward;
        public Vector3 Right => transform.right;
        public Vector3 Left => -Right;
        public Vector3 Up => transform.up;
        public Vector3 Down => -Up;

        private Rigidbody _rigidBody;
        private List<Collider> _ignoreColliders = new();

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void IgnoreCollision(Collider collider)
        {
            if (_ignoreColliders.Contains(collider))
            {
                return;
            }

            if (Collider == collider)
            {
                return;
            }

            Physics.IgnoreCollision(collider, Collider, true);

            _ignoreColliders.Add(collider);
        }

        public void AddForce(Vector3 force)
        {
            _rigidBody.AddForce(force, ForceMode.Impulse);
        }

        public void ResetPhysics()
        {
            _rigidBody.ResetInertiaTensor();

            foreach (var ignoreCollider in _ignoreColliders)
            {
                Physics.IgnoreCollision(ignoreCollider, Collider, false);
            }

            _ignoreColliders.Clear();
        }
    }
}
