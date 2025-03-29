using UGT.Services.UI.Models;
using UnityEngine;

namespace UGT.Common.Gameplay.UI.HUD
{
    [System.Serializable]
    public class GameplayChangerHudModel : UGTHudModel
    {
        [SerializeField]
        private UGTGameplayType _gameplayType;

        public UGTGameplayType GameplayType => _gameplayType;
    }
}
