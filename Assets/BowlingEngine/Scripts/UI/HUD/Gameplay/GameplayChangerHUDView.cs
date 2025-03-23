using BowlingEngine.StaticData.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace BowlingEngine.UI.HUD.Gameplay
{
    public class GameplayChangerHUDView : MonoBehaviour
    {
        public event System.Action<GameplayTypeStaticData> ButtonClicked;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private GameplayTypeStaticData _type;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ButtonClicked?.Invoke(_type);
        }
    }
}
