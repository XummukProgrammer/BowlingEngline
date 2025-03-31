using UnityEngine;
using UnityEngine.UI;
using UnityGameTemplate.Gameplay.Signals;
using Zenject;

namespace UnityGameTemplate.Gameplay.UI
{
    public class GameChangeButton : MonoBehaviour
    {
        private SignalBus _signalBus;
        private Button _button;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            _signalBus.Fire<UGTGameplayChangeSignal>();
        }
    }
}
