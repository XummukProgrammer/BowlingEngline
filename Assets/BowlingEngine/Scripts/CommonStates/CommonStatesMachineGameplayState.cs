using BowlingEngine.Services.AssetsLoader;
using BowlingEngine.Services.StatesMachine.Interfaces;
using BowlingEngine.StaticData.Gameplay;
using BowlingEngine.UI.HUD.Gameplay;
using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.CommonStates
{
    public abstract class CommonStatesMachineGameplayState : IStatesMachineExitableState, IStatesMachineEnterableState
    {
        private GameplayChangerHUDView _gameplayChangerHUDView;

        private readonly AssetsLoaderService _assetsLoaderService;
        private readonly GameplayContainerStaticData _gameplayContainerStaticData;
        private readonly CommonStatesMachineService _commonStatesMachineService;

        public CommonStatesMachineGameplayState(
            AssetsLoaderService assetsLoaderService,
            GameplayContainerStaticData gameplayContainerStaticData,
            CommonStatesMachineService commonStatesMachineService)
        {
            _assetsLoaderService = assetsLoaderService;
            _gameplayContainerStaticData = gameplayContainerStaticData;
            _commonStatesMachineService = commonStatesMachineService;
        }

        public void Enter()
        {
            _gameplayChangerHUDView = GameObject.FindFirstObjectByType<GameplayChangerHUDView>();
            if (_gameplayChangerHUDView != null)
                _gameplayChangerHUDView.ButtonClicked += OnGameplayChangedClicked;
        }

        public void Exit()
        {
            if (_gameplayChangerHUDView != null)
                _gameplayChangerHUDView.ButtonClicked -= OnGameplayChangedClicked;
        }

        private void OnGameplayChangedClicked(GameplayTypeStaticData type)
        {
            _ = ChangeAndClear(type);
        }

        private async Task ChangeAndClear(GameplayTypeStaticData type)
        {
            var gameplayType = GetGameplayType();
            var gameplayData = _gameplayContainerStaticData.Get(gameplayType);

            if (gameplayData != null)
            {
                foreach (var element in gameplayData.Package.Elements)
                    await _assetsLoaderService.Unload(element.name);
            }

            switch (type)
            {
                case GameplayTypeStaticData.Meta:
                    _commonStatesMachineService.ChangeState<CommonStatesMachineLoadMetaGameplayState>();
                    break;

                case GameplayTypeStaticData.Core:
                    _commonStatesMachineService.ChangeState<CommonStatesMachineLoadCoreGameplayState>();
                    break;
            }
        }

        protected abstract GameplayTypeStaticData GetGameplayType();
    }
}
