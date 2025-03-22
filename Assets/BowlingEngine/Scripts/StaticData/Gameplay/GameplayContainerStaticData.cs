using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BowlingEngine.StaticData.Gameplay
{
    [CreateAssetMenu(fileName = "Gameplay Container", menuName = "Bowling Engine/Static Data/Gameplay Container")]
    public class GameplayContainerStaticData : ScriptableObject
    {
        [SerializeField]
        private GameplayStaticData[] _data;

        public IEnumerable<GameplayStaticData> Data => _data;

        public GameplayStaticData Get(GameplayTypeStaticData type)
        {
            return _data.FirstOrDefault(g => g.Type == type);
        }
    }
}
