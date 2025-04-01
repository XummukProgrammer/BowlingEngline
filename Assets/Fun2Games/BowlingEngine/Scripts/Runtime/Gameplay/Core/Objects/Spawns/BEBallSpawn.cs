using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Spawns
{
    public class BEBallSpawn : MonoBehaviour
    {
        public Vector3 Position => transform.position;
        public Quaternion Quaternion => transform.rotation;
    }
}
