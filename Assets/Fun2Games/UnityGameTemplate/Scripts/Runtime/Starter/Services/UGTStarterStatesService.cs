using System.Collections.Generic;
using UnityGameTemplate.Starter.States;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

namespace UnityGameTemplate.Starter.Services
{
    public class UGTStarterStatesService : UGTBaseStatesService
    {
        public UGTStarterStatesService(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> States => new UGTIExitableState[]
        {
            Factory.Create<UGTStarterStatesBoostrap>(),
            Factory.Create<UGTStarterStatesLoad>(),
            Factory.Create<UGTStarterStatesGameplayLoad>(),
            Factory.Create<UGTStarterStatesGameplayInProgress>(),
            Factory.Create<UGTStarterStatesGameplayUnload>(),
            Factory.Create<UGTStarterStatesUnload>(),
            Factory.Create<UGTStarterStatesDisable>(),
        };

        protected override UGTIExitableState DefaultState => Factory.Create<UGTStarterStatesBoostrap>();
    }
}
