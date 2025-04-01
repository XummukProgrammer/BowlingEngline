using BowlingEngine.Gameplay.Core.Objects.Ball;
using BowlingEngine.Gameplay.Core.Objects.Ball.States;
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
        }
    }
}
