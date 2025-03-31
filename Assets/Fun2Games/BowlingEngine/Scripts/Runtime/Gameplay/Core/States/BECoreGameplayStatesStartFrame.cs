using BowlingEngine.Gameplay.Core.Services;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace BowlingEngine.Gameplay.Core.States
{
    public class BECoreGameplayStatesStartFrame
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly BECoreGameplayStatesService _statesService;

        public BECoreGameplayStatesStartFrame(BECoreGameplayStatesService statesService)
        {
            _statesService = statesService;
        }

        public void Enter()
        {
            Debug.Log("BECoreGameplayStatesStartFrame.Enter");
        }

        public void Exit()
        {
            Debug.Log("BECoreGameplayStatesStartFrame.Exit");
        }
    }
}
