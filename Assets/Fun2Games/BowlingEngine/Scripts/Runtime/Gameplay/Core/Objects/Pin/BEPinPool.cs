using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinPool : MonoPoolableMemoryPool<string, Vector2, Vector3, IMemoryPool, BEPinFacade>
    {
    }
}
