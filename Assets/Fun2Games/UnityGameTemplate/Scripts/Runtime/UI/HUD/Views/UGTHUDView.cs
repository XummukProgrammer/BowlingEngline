using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGameTemplate.UI.HUD.Views
{
    public class UGTHUDView : MonoBehaviour
    {
        public event Action Clicked;

        [SerializeField]
        private Button _clickButton;

        private void OnEnable()
        {
            if (_clickButton != null)
            {
                _clickButton.onClick.AddListener(OnClicked);
            }
        }

        private void OnDisable()
        {
            if (_clickButton != null)
            {
                _clickButton.onClick.RemoveListener(OnClicked);
            }
        }

        private void OnClicked()
        {
            Clicked?.Invoke();
        }
    }
}
