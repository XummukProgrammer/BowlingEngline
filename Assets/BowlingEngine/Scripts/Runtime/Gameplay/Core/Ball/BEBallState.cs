using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Ball
{
    public enum BEBallStateType
    {
        Move,
        Drop
    }

    public class BEBallState : MonoBehaviour
    {
        public BEBallStateType StateType { get; set; } = BEBallStateType.Move;
    }
}
