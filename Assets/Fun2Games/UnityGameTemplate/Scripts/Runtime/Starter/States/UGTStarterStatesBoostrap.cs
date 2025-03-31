using System.Linq;
using UnityEngine;
using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.Starter.Models;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTStarterStatesService _statesService;
        private readonly UGTProjectModel _projectModel;
        private readonly UGTGameplayData _gameplayData;
        private readonly UGTGameplaySceneModel _gameplaySceneModel;

        public UGTStarterStatesBoostrap(
            UGTStarterStatesService statesService, 
            UGTProjectModel projectModel,
            UGTGameplayData gameplayData,
            UGTGameplaySceneModel gameplaySceneModel)
        {
            _statesService = statesService;
            _projectModel = projectModel;
            _gameplayData = gameplayData;
            _gameplaySceneModel = gameplaySceneModel;
        }

        public void Enter()
        {
            Debug.Log("A project running Unity Game Template has been launched.");
            Debug.Log("The creator of the system is Xummuk97 (Fun2Games).");

            Debug.Log($"Name - {_projectModel.Name}.");
            Debug.Log($"Description - {_projectModel.Description}.");
            Debug.Log($"Version - {_projectModel.FullVersion}.");

            string authors = "Authors: " + _projectModel.Authors.Aggregate((a1, a2) =>
            {
                return a1 + (!string.IsNullOrEmpty(a1) ? ", " : "") + a2;
            }) + ".";
            Debug.Log(authors);

            _gameplayData.CurrentType = _gameplaySceneModel.DefaultGameplayType;
            _gameplayData.ReadyToBoostrap = false;

            _statesService.EnterState<UGTStarterStatesLoad>();
        }

        public void Exit()
        {
        }
    }
}
