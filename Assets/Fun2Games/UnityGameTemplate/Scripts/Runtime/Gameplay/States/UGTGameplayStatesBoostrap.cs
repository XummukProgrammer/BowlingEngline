using UnityEngine;
using UnityGameTemplate.Gameplay.Models;
using UnityGameTemplate.Gameplay.Services;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.States.Interfaces;
using Zenject;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
    {
        private readonly UGTGameplayStatesService _statesService;
        private readonly UGTGameplayModel _gameplayModel;
        private readonly UGTGameplayData _gameplayData;

        public UGTGameplayStatesBoostrap(
            UGTGameplayStatesService statesService,
            UGTGameplayModel gameplayModel,
            UGTGameplayData gameplayData)
        {
            _statesService = statesService;
            _gameplayModel = gameplayModel;
            _gameplayData = gameplayData;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public void Tick()
        {
            if (_gameplayData.ReadyToBoostrap)
            {
                Debug.Log($"The gameplay with the {_gameplayModel.Type} type has been launched.");

                _statesService.EnterState<UGTGameplayStatesLoad>();
            }
        }
    }
}
