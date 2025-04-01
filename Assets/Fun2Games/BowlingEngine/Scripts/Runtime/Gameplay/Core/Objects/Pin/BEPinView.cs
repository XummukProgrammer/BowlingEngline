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

        public float MaterialBounce
        {
            set
            {
                foreach (var collider in _colliders)
                {
                    collider.material.bounciness = value;
                    collider.material.bounceCombine = PhysicsMaterialCombine.Maximum;
                }
            }
        }

        public Vector3 Forward => transform.forward;
        public Vector3 Back => -Forward;
        public Vector3 Right => transform.right;
        public Vector3 Left => -Right;
        public Vector3 Up => transform.up;
        public Vector3 Down => -Up;

        private Rigidbody _rigidBody;
        private List<Collider> _colliders;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _colliders = GetComponentsInChildren<Collider>().ToList();
        }

        public void IgnoreCollision(Collider collider)
        {
            foreach (var col in _colliders)
            {
                Physics.IgnoreCollision(collider, col);
            }
        }

        public void AddForce(Vector3 force)
        {
            _rigidBody.AddForce(force, ForceMode.Impulse);
        }
    }
}
