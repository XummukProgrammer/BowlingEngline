using System.Linq;
using UnityEngine;
using UnityGameTemplate.Starter.Models;
using Zenject;

namespace UnityGameTemplate.Starter.Services
{
    public class UGTStarterService : IInitializable
    {
        private readonly UGTProjectModel _projectModel;

        public UGTStarterService(UGTProjectModel projectModel)
        {
            _projectModel = projectModel;
        }

        public void Initialize()
        {
            Debug.Log("A project running Unity Game Template has been launched.");
            Debug.Log("The creator of the system is Xummuk97 (Fun2Games).");

            Debug.Log($"Name - {_projectModel.Name}.");
            Debug.Log($"Description - {_projectModel.Description}.");
            Debug.Log($"Version - {_projectModel.FullVersion}.");

            string authors = "Authors: " + _projectModel.Authors.ToList().Aggregate((a1, a2) =>
            {
                return a1 + (!string.IsNullOrEmpty(a1) ? ", " : "") + a2;
            }) + ".";
            Debug.Log(authors);
        }
    }
}
