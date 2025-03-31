using UnityEngine;
using UnityGameTemplate.Gameplay.Models;
using UnityGameTemplate.Gameplay.Services;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;
using Zenject;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTBaseGameplayStatesBoostrap<TMachine, TModel, TNextState>
        : UGTIExitableState
        , UGTIEnterableState
        , ITickable
        where TMachine : UGTBaseStatesService
        where TModel : UGTGameplayModel
        where TNextState : UGTIExitableState
    {
        private readonly TMachine _statesService;
        private readonly TModel _gameplayModel;
        private readonly UGTGameplayData _gameplayData;

        public UGTBaseGameplayStatesBoostrap(
            TMachine statesService,
            TModel gameplayModel,
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

                _statesService.EnterState<TNextState>();
            }
        }
    }

    public class UGTGameplayStatesBoostrap
        : UGTBaseGameplayStatesBoostrap<UGTGameplayStatesService, UGTGameplayModel, UGTGameplayStatesLoad>
    {
        public UGTGameplayStatesBoostrap(
            UGTGameplayStatesService statesService, 
            UGTGameplayModel gameplayModel, 
            UGTGameplayData gameplayData) 
            : base(statesService, 
                  gameplayModel, 
                  gameplayData)
        {
        }
    }
}
