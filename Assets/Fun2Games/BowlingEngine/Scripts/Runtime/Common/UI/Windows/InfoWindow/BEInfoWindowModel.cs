using UnityEngine;
using UnityGameTemplate.UI.Windows.Models;

namespace BowlingEngine.Common.UI.Windows.InfoWindow
{
    [System.Serializable]
    public class BEInfoWindowModel : UGTWindowModel
    {
        [SerializeField]
        private string _selectBallLocalizationID = "info.select_ball";

        public string SelectBallLocalizationID => _selectBallLocalizationID;
    }
}
