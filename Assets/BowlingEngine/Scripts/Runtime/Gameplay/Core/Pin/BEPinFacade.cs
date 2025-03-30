using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinFacade
        : MonoBehaviour
        , IPoolable<IMemoryPool>
        , IDisposable
    {
        private IMemoryPool _pool;

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

        public class Factory : PlaceholderFactory<BEPinFacade>
        {
        }

        public class Pool : MonoPoolableMemoryPool<IMemoryPool, BEPinFacade>
        {
        }
    }
}
