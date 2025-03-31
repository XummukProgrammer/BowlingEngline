using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Resources.Models
{
    [System.Serializable]
    public class UGTResourcesModel
    {
        [SerializeField]
        private UGTResourceModel[] _resources;

        public IEnumerable<UGTResourceModel> Resources => _resources;
    }
}
