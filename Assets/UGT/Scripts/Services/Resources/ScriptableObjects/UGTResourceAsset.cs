using UGT.Services.Resources.Interfaces;
using UnityEngine;

namespace UGT.Services.Resources.ScriptableObjects
{
    public abstract class UGTResourceAsset : ScriptableObject
    {
        [SerializeField]
        private string _path;

        public string Path => _path;

        public abstract UGTIResource Instance { get; }
    }
}
