using UnityEngine;
using UnityGameTemplate.UI.Windows.Views;

namespace UnityGameTemplate.UI.Windows.Models
{
    [System.Serializable]
    public class UGTWindowModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private UGTWindowView _prefab;

        public string ID => _id;
        public UGTWindowView Prefab => _prefab;
    }
}
