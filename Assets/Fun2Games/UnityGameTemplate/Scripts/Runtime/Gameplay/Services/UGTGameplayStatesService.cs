using System.Collections.Generic;
using UnityGameTemplate.Gameplay.States;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

namespace UnityGameTemplate.Gameplay.Services
{
    public class UGTGameplayStatesService : UGTBaseStatesService
    {
        public UGTGameplayStatesService(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> States => new UGTIExitableState[]
        {
            Factory.Create<UGTGameplayStatesBoostrap>(),
            Factory.Create<UGTGameplayStatesLoad>(),
            Factory.Create<UGTGameplayStatesInProgress>(),
            Factory.Create<UGTGameplayStatesUnload>(),
            Factory.Create<UGTGameplayStatesDisable>()
        };

        protected override UGTIExitableState DefaultState => Factory.Create<UGTGameplayStatesBoostrap>();
    }
}
