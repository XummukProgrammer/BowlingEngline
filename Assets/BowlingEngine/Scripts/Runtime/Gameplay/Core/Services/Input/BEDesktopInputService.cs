using BowlingEngine.Gameplay.Core.Services.Input.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Services.Input
{
    public class BEDesktopInputService 
        : BEIInput
        , ITickable
    {
        public float HorizontalDiff { get; private set; }

        public void Tick()
        {
            HorizontalDiff = UnityEngine.Input.GetAxisRaw("Horizontal");
        }
    }
}
