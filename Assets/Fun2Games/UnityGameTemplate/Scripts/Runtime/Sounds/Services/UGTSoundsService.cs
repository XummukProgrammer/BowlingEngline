using UnityEngine;
using UnityGameTemplate.Sounds.Views;
using Zenject;

namespace UnityGameTemplate.Sounds.Services
{
    public class UGTSoundsService : IInitializable
    {
        private UGTSoundsContainerView _containerView;

        public void Initialize()
        {
            _containerView = GameObject.FindFirstObjectByType<UGTSoundsContainerView>();
        }

        public void CreateSound(string soundID, AudioClip audioClip)
        {
            _containerView.CreateSound(soundID, audioClip);
        }

        public void DestroySound(string soundID)
        {
            _containerView.DestroySound(soundID);
        }

        public void PlaySound(string soundID, float volume = 1)
        {
            _containerView.PlaySound(soundID, volume);
        }

        public void StopSound(string soundID)
        {
            _containerView.StopSound(soundID);
        }
    }
}
