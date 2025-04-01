using System;
using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinFacade : MonoBehaviour, IPoolable<Vector3, IMemoryPool>, IDisposable
    {
        public BEPinStates States { get; private set; }

        private BEPinView _view;
        private BEPinRegistry _registry;
        private IMemoryPool _pool;

        [Inject]
        public void Construct(
            BEPinView view, 
            BEPinStates states,
            BEPinRegistry registry)
        {
            _view = view;
            _registry = registry;

            States = states;
        }

        public void OnSpawned(Vector3 position, IMemoryPool pool)
        {
            _pool = pool;

            _view.Position = position;
        
            _registry.AddPin(this);
        }

        public void OnDespawned()
        {
            _pool = null;

            _registry.RemovePin(this);
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
    }
}
