using BowlingEngine.Gameplay.Core.Models;
using BowlingEngine.Gameplay.Core.Services;
using UnityGameTemplate.Gameplay.States;
using UnityGameTemplate.Starter.Installers;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesBoostrap
        : UGTBaseGameplayStatesBoostrap<BECoreGameplayStatesService, BECoreGameplayModel, BECoreGameplayStatesLoad>
    {
        public BECoreGameplayStatesBoostrap(
            BECoreGameplayStatesService statesService, 
            BECoreGameplayModel gameplayModel, 
            UGTGameplayData gameplayData) 
            : base(statesService, 
                  gameplayModel, 
                  gameplayData)
        {
        }
    }
}
