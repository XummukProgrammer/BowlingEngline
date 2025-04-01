using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinBounceHandler
    {
        private readonly BEPinView _view;

        public BEPinBounceHandler(BEPinView view)
        {
            _view = view;
        }

        public void Bounce(Collider collider)
        {
            _view.MaterialBounce = 0.6f;

            _view.IgnoreCollision(collider);

            var dirs = new Vector3[]
            {
                Vector3.zero,
                _view.Left,
                _view.Right
            };

            var dir = _view.Position.x < collider.transform.position.x ? _view.Left : _view.Right;

            _view.AddForce(_view.Up + _view.Forward + dir);
        }
    }
}
