using BowlingEngine.Gameplay.Core.Services.Input.Interfaces;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public class BEBall : MonoBehaviour
    {
        private BEIInput _input;

        private Rigidbody _rigidBody;

        [Inject]
        public void Construct(BEIInput input)
        {
            _input = input;
        }

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidBody.linearVelocity = new Vector3(_input.HorizontalDiff, 0);
        }
    }
}
