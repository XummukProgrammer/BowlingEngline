using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinPool : MonoPoolableMemoryPool<Vector3, IMemoryPool, BEPinFacade>
    {
    }
}
