using UnityEngine;
using UnityGameTemplate.UI.Windows.Views;

namespace BowlingEngine.Common.UI.Windows.InfoWindow
{
    public class BEInfoWindowView : UGTWindowView
    {
        public string Info
        {
            get => _infoText.text;
            set => _infoText.text = value;
        }

        [SerializeField]
        private TMPro.TMP_Text _infoText;
    }
}
