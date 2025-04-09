using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.UI.HUD.Views;

namespace UnityGameTemplate.UI.HUD.Common.Message
{
    public class UGTMessageHUDView : UGTHUDView
    {
        [SerializeField]
        private UGTMessageHUDPlaceTextModel[] _texts;

        private Dictionary<UGTMessageHUDPlaceType, UGTMessageHUDPlaceTextController> _controllers = new();

        private void Awake()
        {
            foreach (var textModel in _texts)
            {
                _controllers.Add(textModel.PlaceType, new(textModel));
            }
        }

        private void OnDestroy()
        {
            _controllers.Clear();
        }

        private void Update()
        {
            foreach (var controller in _controllers)
            {
                controller.Value.OnUpdate();
            }
        }

        public void ShowText(UGTMessageHUDPlaceType placeType, string text, float time, bool isUnlimitedTime)
        {
            if (_controllers.TryGetValue(placeType, out var controller))
            {
                controller.ShowText(text, time, isUnlimitedTime);
            }
        }
    }
}
