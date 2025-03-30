using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Aim
{
    public class BEAimView : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}
