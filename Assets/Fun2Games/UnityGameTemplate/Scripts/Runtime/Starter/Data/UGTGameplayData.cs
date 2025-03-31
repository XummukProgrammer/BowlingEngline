using UnityGameTemplate.Gameplay.Models;

namespace UnityGameTemplate.Starter.Installers
{
    public class UGTGameplayData
    {
        public UGTGameplayType CurrentType { get; set; }

        public bool ReadyToBoostrap { get; set; }
        public bool Disable { get; set; }
    }
}
