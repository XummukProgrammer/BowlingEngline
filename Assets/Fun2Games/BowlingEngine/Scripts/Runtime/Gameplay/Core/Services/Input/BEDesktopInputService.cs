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
        }
    }
}
