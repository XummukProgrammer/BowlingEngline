using UnityEngine;

namespace UnityGameTemplate.Gameplay.Models
{
    [System.Serializable]
    public class UGTGameplayModel
    {
        [SerializeField]
        private UGTGameplayType _type;

        public UGTGameplayType Type => _type;
    }
}
