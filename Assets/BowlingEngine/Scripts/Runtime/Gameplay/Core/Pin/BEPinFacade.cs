using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Pin
{
    public class BEPinFacade
        : MonoBehaviour
        , IPoolable<Vector3, IMemoryPool>
        , IDisposable
    {
        private BEPinView _view;
        private IMemoryPool _pool;

        [Inject]
        public void Construct(BEPinView view)
        {
            _view = view;
        }

        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            _pool = pool;

            _view.Position = position;
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }

        public class Factory : PlaceholderFactory<Vector3, BEPinFacade>
        {
        }

        public class Pool : MonoPoolableMemoryPool<Vector3, IMemoryPool, BEPinFacade>
        {
        }
    }
}
