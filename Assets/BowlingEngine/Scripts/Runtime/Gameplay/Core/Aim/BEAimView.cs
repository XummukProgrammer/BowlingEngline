using Dreamteck.Splines;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Aim
{
    public class BEAimView : MonoBehaviour
    {
        public SplineComputer SplineComputer => _splineComputer;

        [SerializeField]
        private SplineComputer _splineComputer;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}
