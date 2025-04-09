using UnityEngine;

namespace UnityGameTemplate.UI.HUD.Common.Message
{
    public class UGTMessageHUDPlaceTextController
    {
        private readonly UGTMessageHUDPlaceTextModel _model;

        private bool _isShowed;
        private float _time;
        private bool _isUnlimitedTime;

        public UGTMessageHUDPlaceTextController(UGTMessageHUDPlaceTextModel model)
        {
            _model = model;
        }

        public void ShowText(string text, float time, bool isUnlimitedTime)
        {
            _model.Text.text = text;
            
            _time = time;
            _isUnlimitedTime = isUnlimitedTime;
            _isShowed = true;
        }

        public void OnUpdate()
        {
            if (_isShowed && !_isUnlimitedTime)
            {
                _time -= Time.deltaTime;

                if (_time <= 0)
                {
                    _model.Text.text = "";

                    _time = 0;
                    _isShowed = false;
                }
            }
        }
    }
}
