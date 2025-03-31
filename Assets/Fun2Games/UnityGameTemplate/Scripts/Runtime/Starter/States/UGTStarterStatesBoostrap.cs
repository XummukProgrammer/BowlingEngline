using System.Linq;
using UnityEngine;
using UnityGameTemplate.Starter.Models;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesBoostrap
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTProjectModel _projectModel;

        public UGTStarterStatesBoostrap(UGTProjectModel projectModel)
        {
            _projectModel = projectModel;
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
        }

        public void Exit()
        {
        }
    }
}
