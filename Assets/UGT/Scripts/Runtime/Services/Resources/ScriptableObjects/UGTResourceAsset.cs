using System.Collections.Generic;
using UGT.Services.Resources.Interfaces;
using UGT.Services.Resources.Models;
using UnityEngine;

namespace UGT.Services.Resources.ScriptableObjects
{
    public abstract class UGTResourceAsset : ScriptableObject
    {
        [SerializeField]
        private string _path;

        public string Path => _path;
        public abstract UGTResourceDependencyType[] Dependencies { get; }

        public abstract UGTIResource CreateInstance(UGTResourceDependenciesModel dependencies);
    }
}
