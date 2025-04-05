using UnityEngine;
using UnityGameTemplate.UI.Windows.Models;

namespace UnityGameTemplate.UI.Windows.Common.LoadWindow
{
    [System.Serializable]
    public class UGTLoadWindowModel : UGTWindowModel
    {
        [SerializeField]
        private string _descriptionLocalizationID = "resources.load";

        public string DescriptionLocalizationID => _descriptionLocalizationID;
    }
}
