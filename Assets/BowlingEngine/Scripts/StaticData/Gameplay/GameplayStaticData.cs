using BowlingEngine.StaticData.AssetsLoader;
using UnityEngine;

namespace BowlingEngine.StaticData.Gameplay
{
    [CreateAssetMenu(fileName = "Gameplay", menuName = "Bowling Engine/Static Data/Gameplay")]
    public class GameplayStaticData : ScriptableObject
    {
        [SerializeField]
        private GameplayTypeStaticData _type;

        [SerializeField]
        private AssetsLoaderPackageStaticData _package;

        public GameplayTypeStaticData Type => _type;
        public AssetsLoaderPackageStaticData Package => _package;
    }
}
