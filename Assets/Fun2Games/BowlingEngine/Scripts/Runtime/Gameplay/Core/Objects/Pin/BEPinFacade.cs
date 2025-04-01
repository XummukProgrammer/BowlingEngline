using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinFacade : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        public BEPinStates States { get; private set; }

        private IMemoryPool _pool;

        [Inject]
        public void Construct(BEPinStates states)
        {
            States = states;
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
    }
}
