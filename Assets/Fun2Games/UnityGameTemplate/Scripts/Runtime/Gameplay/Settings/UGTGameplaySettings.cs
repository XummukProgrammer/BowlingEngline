using UnityEngine;
using UnityGameTemplate.Gameplay.Models;
using Zenject;

namespace UnityGameTemplate.Gameplay.Settings
{
    public class UGTBaseGameplaySettings<T> : ScriptableObjectInstaller<UGTBaseGameplaySettings<T>>
        where T : UGTGameplayModel
    {
        [SerializeField]
        private T _gameplayModel;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameplayModel);
        }
    }

    [CreateAssetMenu(fileName = "Gameplay Settings", menuName = "Unity Game Template/Gameplay/Settings")]
    public class UGTGameplaySettings : UGTBaseGameplaySettings<UGTGameplayModel>
    {
    }
}
