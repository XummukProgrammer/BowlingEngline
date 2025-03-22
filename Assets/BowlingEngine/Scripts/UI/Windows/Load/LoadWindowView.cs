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

        public float CurrentPercent
        {
            get => _progressBar.currentPercent;
            set => _progressBar.currentPercent = value;
        }

        public float MinValue
        {
            get => _progressBar.minValue;
            set => _progressBar.minValue = value;
        }

        public float MaxValue
        {
            get => _progressBar.maxValue;
            set => _progressBar.maxValue = value;
        }

        [SerializeField]
        private ProgressBar _progressBar;
    }
}
