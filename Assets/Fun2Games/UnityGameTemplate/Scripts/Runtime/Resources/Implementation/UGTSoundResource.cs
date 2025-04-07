using System.Threading.Tasks;
using UnityEngine;
using UnityGameTemplate.Sounds.Services;

namespace UnityGameTemplate.Resources.Implementation
{
    public class UGTSoundResource : UGTCommonResource<AudioClip>
    {
        private readonly UGTSoundsService _soundsService;

        public UGTSoundResource(
            string id, 
            string path,
            UGTSoundsService soundsService) 
            : base(id, path)
        {
            _soundsService = soundsService;
        }

        protected override async Task OnLoaded()
        {
            _soundsService.CreateSound(ID, Result);
        }

        protected override async Task OnUnloaded()
        {
            _soundsService.DestroySound(ID);
        }
    }
}
