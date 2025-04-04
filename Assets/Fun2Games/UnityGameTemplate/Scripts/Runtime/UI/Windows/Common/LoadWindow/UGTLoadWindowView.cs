using UnityEngine;
using UnityGameTemplate.UI.Windows.Views;

namespace UnityGameTemplate.UI.Windows.Common.LoadWindow
{
    public class UGTLoadWindowView : UGTWindowView
    {
        public string GameName
        {
            get => _gameNameText.text;
            set => _gameNameText.text = value;
        }

        public string Version
        {
            get => _versionText.text;
            set => _versionText.text = value;
        }

        public string CompanyName
        {
            get => _companyNameText.text;
            set => _companyNameText.text = value;
        }

        [SerializeField]
        private TMPro.TMP_Text _gameNameText;

        [SerializeField]
        private TMPro.TMP_Text _versionText;

        [SerializeField]
        private TMPro.TMP_Text _companyNameText;
    }
}
