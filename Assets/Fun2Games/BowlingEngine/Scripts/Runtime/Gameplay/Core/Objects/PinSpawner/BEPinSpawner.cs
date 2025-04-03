using BowlingEngine.Gameplay.Core.Objects.Pin;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.PinSpawner
{
    public class BEPinSpawner : MonoBehaviour
    {
        public IEnumerable<BEPinSpawnerRow> Rows => GetComponentsInChildren<BEPinSpawnerRow>();

        private List<List<Transform>> _colMatrix = new();

        private BEPinFactory _pinFactory;

        [Inject]
        public void Construct(BEPinFactory pinFactory)
        {
            _pinFactory = pinFactory;
        }

        private void Awake()
        {
            foreach (var row in Rows)
            {
                var transforms = new List<Transform>();
                foreach (var col in row.Cols)
                {
                    transforms.Add(col.transform);
                }

                _colMatrix.Add(transforms);
            }
        }

        public void Spawn(int x, int y)
        {
            var transform = _colMatrix[y][x];

            _pinFactory.Create(new Vector2(x, y), transform.position);
        }
    }
}
