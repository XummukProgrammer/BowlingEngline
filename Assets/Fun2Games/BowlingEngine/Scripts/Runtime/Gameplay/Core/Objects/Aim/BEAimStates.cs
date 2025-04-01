using BowlingEngine.Gameplay.Core.Objects.Aim.States;
using System.Collections.Generic;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

namespace BowlingEngine.Gameplay.Core.Objects.Aim
{
    public class BEAimStates : UGTBaseStatesService
    {
        public BEAimStates(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> States => new UGTIExitableState[]
        {
            Factory.Create<BEAimStatesDisable>(),
            Factory.Create<BEAimStatesBoostrap>(),
            Factory.Create<BEAimStatesIdentifyDir>(),
            Factory.Create<BEAimStatesGenerate>(),
            Factory.Create<BEAimStatesStay>()
        };

        protected override UGTIExitableState DefaultState => Factory.Create<BEAimStatesDisable>();
    }
}
