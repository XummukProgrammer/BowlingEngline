using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UnityGameTemplate.Gameplay.States
{
    public class GameDisableButton : MonoBehaviour
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
            _signalBus.Fire<UGTGameplayDisableSignal>();
        }
    }
}
