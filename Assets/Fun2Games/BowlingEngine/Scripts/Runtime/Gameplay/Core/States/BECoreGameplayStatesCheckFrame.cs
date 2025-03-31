using BowlingEngine.Gameplay.Core.Data;
using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Services;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesCheckFrame
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;
        private readonly BECoreGameplayFrameData _frameData;
        private readonly BECoreGameplayModel _gameplayModel;

        public BECoreGameplayStatesCheckFrame(
            BECoreGameplayStatesService statesService,
            BECoreGameplayFrameData frameData,
            BECoreGameplayModel gameplayModel)
        {
            _statesService = statesService;
            _frameData = frameData;
            _gameplayModel = gameplayModel;
        }

        public void Enter()
        {
            int perfectSteps = _gameplayModel.MaxSteps - _frameData.StepsCount;
            Debug.Log($"A step has been taken in the game frame ({perfectSteps}/{_gameplayModel.MaxSteps}).");

            if (_frameData.StepsCount == 0)
            {
                _statesService.EnterState<BECoreGameplayStatesFinishFrame>();
            }
            else
            {
                _statesService.EnterState<BECoreGameplayStatesStepFrame>();
            }
        }

        public void Exit()
        {
        }
    }
}
