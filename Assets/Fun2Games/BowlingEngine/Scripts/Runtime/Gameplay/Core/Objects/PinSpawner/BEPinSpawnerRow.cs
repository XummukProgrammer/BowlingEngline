using System.Collections.Generic;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.PinSpawner
{
    public class BEPinSpawnerRow : MonoBehaviour
    {
        public IEnumerable<BEPinSpawnerCol> Cols => GetComponentsInChildren<BEPinSpawnerCol>();
    }
}
