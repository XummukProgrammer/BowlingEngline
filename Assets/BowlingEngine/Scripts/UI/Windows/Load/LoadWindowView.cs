using BowlingEngine.Services.AssetsLoader;
using Michsky.MUIP;
using UnityEngine;
using Zenject;

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

        private AssetsLoaderService _assetsLoaderService;

        [Inject]
        public void Construct(AssetsLoaderService assetsLoaderService)
        {
            _assetsLoaderService = assetsLoaderService;
        }

        private void Start()
        {
            _assetsLoaderService.PackageStartedLoading += OnPackageStartedLoading;
            _assetsLoaderService.PackageFinishedLoading += OnPackageFinishedLoading;

            _assetsLoaderService.PackageUploadedResource += OnPackageUploadedResource;
        }

        private void OnDestroy()
        {
            _assetsLoaderService.PackageStartedLoading -= OnPackageStartedLoading;
            _assetsLoaderService.PackageFinishedLoading -= OnPackageFinishedLoading;

            _assetsLoaderService.PackageUploadedResource -= OnPackageUploadedResource;
        }

        public void ChangeStatus(string newStatus, int maxValue)
        {
            StatusText = newStatus;
            MaxValue = maxValue;
            CurrentValue = 0;
        }

        private void OnPackageStartedLoading(int count)
        {
            ChangeStatus("Загружаем пакет...", count);
        }

        private void OnPackageFinishedLoading()
        {
        }

        private void OnPackageUploadedResource(int index)
        {
            CurrentValue = index;
        }
    }
}
