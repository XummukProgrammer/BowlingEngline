using BowlingEngine.Gameplay.Core.Objects.Ball.States;
using System.Collections.Generic;
using UnityGameTemplate.States.Factories;
using UnityGameTemplate.States.Interfaces;
using UnityGameTemplate.States.Services;

namespace BowlingEngine.Gameplay.Core.Objects.Ball
{
    public class BEBallStates : UGTBaseStatesService
    {
        public BEBallStates(UGTStateFactory factory) 
            : base(factory)
        {
        }

        protected override IEnumerable<UGTIExitableState> States => new UGTIExitableState[]
        {
            Factory.Create<BEBallStatesDisable>(),
            Factory.Create<BEBallStatesBoostrap>(),
            Factory.Create<BEBallStatesMove>(),
            Factory.Create<BEBallStatesDrop>()
        };

        protected override UGTIExitableState DefaultState => Factory.Create<BEBallStatesDisable>();
    }
}
