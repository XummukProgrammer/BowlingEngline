using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.Starter.Models;
using Zenject;

namespace UnityGameTemplate.Sounds.Views
{
    public class UGTSoundsContainerView : MonoBehaviour
    {
        [SerializeField]
        private Transform _container;

        private UGTGameplaySceneModel _gameplaySceneModel;
        private Dictionary<string, AudioSource> _sources = new();

        [Inject]
        public void Construct(UGTGameplaySceneModel gameplaySceneModel)
        {
            _gameplaySceneModel = gameplaySceneModel;
        }

        public void CreateSound(string soundID, AudioClip audioClip)
        {
            var newSound = Instantiate(_gameplaySceneModel.AudioSourcePrefab, _container);
            newSound.name = soundID;
            newSound.clip = audioClip;
            _sources.Add(soundID, newSound);
        }

        public void DestroySound(string soundID)
        {
            if (_sources.TryGetValue(soundID, out var source))
            {
                Destroy(source.gameObject);

                _sources.Remove(soundID);
            }
        }

        public void PlaySound(string soundID, float volume)
        {
            if (_sources.TryGetValue(soundID, out var source))
            {
                source.Play();
            }
        }

        public void StopSound(string soundID)
        {
            if (_sources.TryGetValue(soundID, out var source))
            {
                source.Stop();
            }
        }
    }
}
