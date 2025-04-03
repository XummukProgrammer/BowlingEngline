using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Ball.States;
using BowlingEngine.Gameplay.Core.Objects.Data;
using BowlingEngine.Gameplay.Core.Objects.Pin;
using UnityGameTemplate.States.Factories;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers.Objects
{
    public class BEBallInstaller : MonoInstaller<BEBallInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UGTStateFactory>().AsSingle();

            Container.Bind<BEBallStatesDisable>().AsSingle();
            Container.Bind<BEBallStatesBoostrap>().AsSingle();
            Container.Bind<BEBallStatesMove>().AsSingle();
            Container.Bind<BEBallStatesDrop>().AsSingle();

            Container.BindInterfacesAndSelfTo<BEBallStates>().AsSingle();

            Container.Bind<BEHealthData>().AsSingle();
            Container.Bind<BESpeedData>().AsSingle();

            Container.Bind<BEBallTunables>().AsSingle();
        }
    }
}
