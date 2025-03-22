using Michsky.MUIP;
using UnityEngine;

namespace BowlingEngine.UI.Windows.Load
{
    public class LoadWindowView : MonoBehaviour
    {
        public bool IsEnabled
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public int MaxValue { get; set; }

        public int CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;

                _progressBar.currentPercent = ((float)_currentValue / (float)MaxValue) * 100f;
                _progressBar.UpdateUI();
            }
        }

        public string StatusText
        {
            get => _statusText.text;
            set => _statusText.text = value;
        }

        [SerializeField]
        private ProgressBar _progressBar;

        [SerializeField]
        private TMPro.TMP_Text _statusText;

        private int _currentValue;

        public void ChangeStatus(string newStatus, int maxValue)
        {
            StatusText = newStatus;
            MaxValue = maxValue;
            CurrentValue = 0;
        }
    }
}
