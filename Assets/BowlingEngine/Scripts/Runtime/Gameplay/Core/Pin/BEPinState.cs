using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public enum BEPinStateType
    {
        Stay,
        Bounce
    }

    public class BEPinState : MonoBehaviour
    {
        public BEPinStateType StateType {  get; set; }
    }
}
