using UnityEngine;

namespace UnityGameTemplate.UI.HUD.Common.Message
{
    public class UGTMessageHUDPlaceTextController
    {
        private readonly UGTMessageHUDPlaceTextModel _model;

        private bool _isShowed;
        private float _time;

        public UGTMessageHUDPlaceTextController(UGTMessageHUDPlaceTextModel model)
        {
            _model = model;
        }

        public void ShowText(string text, float time)
        {
            _model.Text.text = text;
            
            _time = time;
            _isShowed = true;
        }

        public void OnUpdate()
        {
            if (_isShowed)
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
