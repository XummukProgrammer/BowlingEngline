using System.Collections.Generic;
using UnityEngine;

namespace UnityGameTemplate.Starter.Models
{
    [System.Serializable]
    public class UGTProjectModel
    {
        [SerializeField]
        private string _name = "Project";

        [SerializeField]
        private string _description = "Description";

        [SerializeField]
        private string _majorVersion = "1";

        [SerializeField]
        private string _minorVersion = "0";

        [SerializeField]
        private string _commit = "6e40183";

        [SerializeField]
        private string[] _authors = new[] { "Xummuk97" };

        public string Name => _name;
        public string Description => _description;
        public string MajorVersion => _majorVersion;
        public string MinorVersion => _minorVersion;
        public string Commit => _commit;
        public string FullVersion => $"{_majorVersion}.{_minorVersion}.{_commit}";
        public IEnumerable<string> Authors => _authors;
    }
}
