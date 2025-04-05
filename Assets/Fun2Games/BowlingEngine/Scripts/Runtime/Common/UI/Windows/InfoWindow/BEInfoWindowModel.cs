using UnityEngine;
using UnityGameTemplate.UI.Windows.Models;

namespace BowlingEngine.Common.UI.Windows.InfoWindow
{
    [System.Serializable]
    public class BEInfoWindowModel : UGTWindowModel
    {
        [SerializeField]
        private string _selectBallLocalizationID = "info.select_ball";

        [SerializeField]
        private string _frameStepLocalizationID = "info.frame_step";

        public string SelectBallLocalizationID => _selectBallLocalizationID;
        public string FrameStepLocalizationID => _frameStepLocalizationID;
    }
}
