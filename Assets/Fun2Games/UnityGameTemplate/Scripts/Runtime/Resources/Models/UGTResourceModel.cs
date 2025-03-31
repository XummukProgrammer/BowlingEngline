using UnityEngine;

namespace UnityGameTemplate.Resources.Models
{
    [System.Serializable]
    public class UGTResourceModel
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private string _path;

        [SerializeField]
        private UGTResourceType _type;

        public string ID => _id;
        public string Path => _path;
        public UGTResourceType Type => _type;
    }
}
