using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Services.Input
{
    public class BEDesktopInputService 
        : BEIInput
        , ITickable
    {
        public bool Enable { get; set; } = false;

        public Vector3 Velocity { get; private set; }
        public Vector3 Rotate { get; private set; }

        public bool Drop { get; private set; }
        public bool LeftArrow { get; private set; }
        public bool RightArrow { get; private set; }
        public bool Select { get; private set; }

        public void Tick()
        {
            if (!Enable)
            {
                return;
            }

            Velocity = new Vector3(UnityEngine.Input.GetAxisRaw("Horizontal"), 0);

            Drop = UnityEngine.Input.GetKeyDown(KeyCode.Return);
            LeftArrow = UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow);
            RightArrow = UnityEngine.Input.GetKeyDown(KeyCode.RightArrow);
            Select = Drop;

            if (UnityEngine.Input.GetKey(KeyCode.Q))
            {
                Rotate = new Vector3(0, -120f);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.E))
            {
                Rotate = new Vector3(0, 120f);
            }
            else
            {
                Rotate = Vector3.zero;
            }
        }
    }
}
