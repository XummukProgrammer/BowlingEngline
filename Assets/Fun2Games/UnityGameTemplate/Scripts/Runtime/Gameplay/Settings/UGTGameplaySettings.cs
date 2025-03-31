using UnityEngine;
using UnityGameTemplate.Gameplay.Models;
using Zenject;

namespace UnityGameTemplate.Gameplay.Settings
{
    [CreateAssetMenu(fileName = "Gameplay Settings", menuName = "Unity Game Template/Gameplay/Settings")]
    public class UGTGameplaySettings : ScriptableObjectInstaller<UGTGameplaySettings>
    {
        [SerializeField]
        private UGTGameplayModel _gameplayModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameplayModel);
        }
    }
}
