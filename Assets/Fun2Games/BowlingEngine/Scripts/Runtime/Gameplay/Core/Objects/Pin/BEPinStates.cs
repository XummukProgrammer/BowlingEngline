using BowlingEngine.Gameplay.Core.Objects.Pin.States;
using System.Collections.Generic;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinStates : UGTBaseStatesService
    {
        public BEPinStates(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> States => new UGTIExitableState[]
        {
            Factory.Create<BEPinStatesStay>(),
            Factory.Create<BEPinStatesBounce>(),
            Factory.Create<BEPinStatesDisable>()
        };

        protected override UGTIExitableState DefaultState => Factory.Create<BEPinStatesDisable>();
    }
}
