using System.Collections.Generic;
using UGT.Services.Resources.ScriptableObjects;
using UnityEngine;

namespace UGT.Services.Resources.Models
{
    [System.Serializable]
    public class UGTResourcesModel
    {
        [SerializeField]
        private UGTResourceAsset[] _resources;

        public IEnumerable<UGTResourceAsset> Resources => _resources;
    }
}
