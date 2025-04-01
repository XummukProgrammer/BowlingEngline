using BowlingEngine.Gameplay.Core.Objects.Aim;
using BowlingEngine.Gameplay.Core.Objects.Aim.States;
using UnityGameTemplate.States.Factories;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers.Objects
{
    public class BEAimInstaller : MonoInstaller<BEAimInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UGTStateFactory>().AsSingle();

            Container.Bind<BEAimStatesBoostrap>().AsSingle();
            Container.Bind<BEAimStatesIdentifyDir>().AsSingle();

            Container.BindInterfacesAndSelfTo<BEAimStates>().AsSingle();
        }
    }
}
