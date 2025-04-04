using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityGameTemplate.UI.Windows.Views
{
    public class UGTWindowView : MonoBehaviour
    {
        public event Action CloseClicked;

        [SerializeField]
        private Button _closeButton;

        private void OnEnable()
        {
            if (_closeButton != null)
            {
                _closeButton.onClick.AddListener(OnCloseClicked);
            }
        }

        private void OnDisable()
        {
            if (_closeButton != null)
            {
                _closeButton.onClick.RemoveListener(OnCloseClicked);
            }
        }

        private void OnCloseClicked()
        {
            CloseClicked?.Invoke();
        }
    }
}
