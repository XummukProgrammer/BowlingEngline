using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesFinishParty
        : UGTIExitableState
        , UGTIEnterableState
    {
        public void Enter()
        {
            Debug.Log("The game party is over.");
        }

        public void Exit()
        {
        }
    }
}
