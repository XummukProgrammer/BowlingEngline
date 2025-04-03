using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Pin.States;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinBounceHandler
    {
        private readonly BEPinView _view;
        private readonly BEBallView _ballView;
        private readonly BEPinRegistry _pinRegistry;

        public BEPinBounceHandler(
            BEPinView view,
            BEBallView ballView,
            BEPinRegistry pinRegistry)
        {
            _view = view;
            _ballView = ballView;
            _pinRegistry = pinRegistry;
        }

        public void BounceWithBall(Collider collider)
        {
            _view.MaterialBounce = _view.Facade.Bounce;

            _view.IgnoreCollision(collider);

            var dir = Vector3.zero;
            var ballPosition = collider.transform.position;

            if (ballPosition.x >= (_view.Position.x - 0.1f) && ballPosition.x <= (_view.Position.x + 0.1f))
            {
                var dirs = new Vector3[]
                {
                    _view.Left,
                    _view.Right
                };

                dir = dirs[Random.Range(0, dirs.Length)];
            }
            else if (_view.Position.x < ballPosition.x)
            {
                dir = _view.Left;
            }
            else if (_view.Position.x > ballPosition.x)
            {
                dir = _view.Right;
            }

            _view.AddForce(
                _view.Up * _ballView.Facade.UpForceForPin 
                + _view.Forward * _ballView.Facade.ForwardForceForPin 
                + dir * _ballView.Facade.DirForceForPin);

            _view.Facade.States.EnterState<BEPinStatesBounce>();

            _ballView.Facade.Health -= _view.Facade.DamageForBall;
        }

        public void BounceWithPin(BEPinView pinView, Collider collider)
        {
            _view.MaterialBounce = _view.Facade.Bounce;
            //pinView.MaterialBounce = 0.6f;

            //_view.ResetPhysics();
            //pinView.ResetPhysics();

            /*foreach (var pin in _pinRegistry.Pins)
            {
                if (pinView.Collider != pin.View.Collider)
                {
                    pinView.IgnoreCollision(pin.View.Collider);
                }
            }*/

            _view.IgnoreCollision(_ballView.Collider);
            pinView.IgnoreCollision(_ballView.Collider);

            var viewForce = Vector3.zero;
            var pinViewForce = Vector3.zero;

            if (_view.Position.x < pinView.Position.x)
            {
                viewForce = _view.Up * pinView.Facade.UpForceForPin 
                    + _view.Left * pinView.Facade.DirForceForPin;

                pinViewForce = pinView.Up * _view.Facade.UpForceForPin 
                    + pinView.Right * _view.Facade.DirForceForPin;
            }
            else if (_view.Position.x > pinView.Position.x)
            {
                viewForce = _view.Up * pinView.Facade.UpForceForPin
                    + _view.Right * pinView.Facade.DirForceForPin;

                pinViewForce = pinView.Up * _view.Facade.UpForceForPin
                    + pinView.Left * _view.Facade.DirForceForPin;
            }

            _view.AddForce(viewForce);
            pinView.AddForce(pinViewForce);

            _view.Facade.Health -= pinView.Facade.DamageForPin;
            pinView.Facade.Health -= _view.Facade.DamageForPin;

            _view.Facade.States.EnterState<BEPinStatesBounce>();
        }
    }
}
