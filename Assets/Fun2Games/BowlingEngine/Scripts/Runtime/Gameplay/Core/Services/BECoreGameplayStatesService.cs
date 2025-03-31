using BowlingEngine.Gameplay.Core.States;
using System.Collections.Generic;
using UnityGameTemplate.Gameplay.States;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

namespace BowlingEngine.Gameplay.Core.Services
{
    public class BECoreGameplayStatesService : UGTBaseStatesService
    {
        public BECoreGameplayStatesService(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> States => new UGTIExitableState[]
        {
            Factory.Create<BECoreGameplayStatesBoostrap>(),
            Factory.Create<BECoreGameplayStatesLoad>(),
            Factory.Create<BECoreGameplayStatesStartParty>(),
            Factory.Create<BECoreGameplayStatesStartFrame>(),
            Factory.Create<BECoreGameplayStatesStepFrame>(),
            Factory.Create<BECoreGameplayStatesCheckFrame>(),
            Factory.Create<BECoreGameplayStatesFinishFrame>(),
            Factory.Create<BECoreGameplayStatesCheckParty>(),
            Factory.Create<BECoreGameplayStatesFinishParty>(),
            Factory.Create<BECoreGameplayStatesUnload>(),
            Factory.Create<UGTGameplayStatesDisable>()
        };

        protected override UGTIExitableState DefaultState => Factory.Create<BECoreGameplayStatesBoostrap>();
    }
}
