using UnityEngine;

namespace BowlingEngine.Common.UI.HUD.InfoHUD
{
    [System.Serializable]
    public class BEInfoHUDModel
    {
        [SerializeField]
        private string _selectBallLocalizationID = "info.select_ball";

        [SerializeField]
        private string _frameStepLocalizationID = "info.frame_step";

        public string SelectBallLocalizationID => _selectBallLocalizationID;
        public string FrameStepLocalizationID => _frameStepLocalizationID;
    }
}
