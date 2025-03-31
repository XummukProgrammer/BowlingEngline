using UnityEngine;
using UnityGameTemplate.Gameplay.Models;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTGameplayModel _gameplayModel;

        public UGTGameplayStatesBoostrap(UGTGameplayModel gameplayModel)
        {
            _gameplayModel = gameplayModel;
        }

        public void Enter()
        {
            Debug.Log($"The gameplay with the {_gameplayModel.Type} type has been launched.");
        }

        public void Exit()
        {
        }
    }
}
