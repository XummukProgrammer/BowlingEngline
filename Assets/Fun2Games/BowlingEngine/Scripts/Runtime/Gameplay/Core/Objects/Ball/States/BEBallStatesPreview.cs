using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Services.Input;
using BowlingEngine.Gameplay.Core.Signals;
using System.Linq;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Ball.States
{
    public class BEBallStatesPreview
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private int _selectID;

        private readonly BEIInput _input;
        private readonly BECoreGameplayModel _gameplayModel;
        private readonly BEBallView _view;
        private readonly SignalBus _signalBus;

        public BEBallStatesPreview(
            BEIInput input,
            BECoreGameplayModel gameplayModel,
            BEBallView view,
            SignalBus signalBus)
        {
            _input = input;
            _gameplayModel = gameplayModel;
            _view = view;
            _signalBus = signalBus;
        }

        public void Enter()
        {
            SetSkin(_gameplayModel.DefaultBallID);

            _selectID = _gameplayModel.GetBallID(_gameplayModel.DefaultBallID);
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            if (_input.LeftArrow)
            {
                MoveToLeftSkin();
            }
            else if (_input.RightArrow)
            {
                MoveToRightSkin();
            }
            else if (_input.Select)
            {
                Select();
                return;
            }
            else
            {
                return;
            }

            var ballModel = _gameplayModel.GetBall(_selectID);
            SetSkin(ballModel.SkinID);
        }

        private void MoveToLeftSkin()
        {
            _selectID--;

            if (_selectID < 0)
            {
                _selectID = _gameplayModel.Balls.Count() - 1;
            }
        }

        private void MoveToRightSkin()
        {
            _selectID++;

            if (_selectID >= _gameplayModel.Balls.Count())
            {
                _selectID = 0;
            }
        }

        public void Select()
        {
            var ballModel = _gameplayModel.GetBall(_selectID);
            _signalBus.Fire(new BEBallSelectSignal(ballModel.ID));
        }

        private void SetSkin(string skinID)
        {
            _view.SetSkin(skinID);
        }
    }
}
