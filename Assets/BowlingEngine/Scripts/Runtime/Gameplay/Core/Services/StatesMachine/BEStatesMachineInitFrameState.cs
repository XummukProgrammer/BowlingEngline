using BowlingEngine.Gameplay.Core.Pin;
using UGT.Basic.Data;
using UGT.Common.States;
using UnityEngine;

namespace BowlingEngine.Gameplay.Core.Services.StatesMachine
{
    public class BEStatesMachineInitFrameState
        : UGTGameplayChangerableState<BEStatesMachineService, BEStatesMachineUnloadState>
    {
        private readonly BEPinFacade.Factory _pinFactory;

        public BEStatesMachineInitFrameState(
            UGTBasicData basicData, 
            BEStatesMachineService statesMachineService,
            BEPinFacade.Factory pinFactory) 
            : base(basicData, 
                  statesMachineService)
        {
            _pinFactory = pinFactory;
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            _pinFactory.Create(new Vector3(0, 0, 10));
        }
    }
}
