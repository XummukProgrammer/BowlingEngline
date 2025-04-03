using BowlingEngine.Gameplay.Core.Objects.Pin;
using BowlingEngine.Gameplay.Core.Objects.Pin.States;
using UnityGameTemplate.States.Factories;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Installers.Objects
{
    public class BEPinInstaller : Installer<BEPinInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<UGTStateFactory>().AsSingle();

            Container.Bind<BEPinStatesStay>().AsSingle();
            Container.Bind<BEPinStatesBounce>().AsSingle();
            Container.Bind<BEPinStatesDisable>().AsSingle();

            Container.BindInterfacesAndSelfTo<BEPinStates>().AsSingle();

            Container.Bind<BEPinBounceHandler>().AsSingle();
            Container.Bind<BEPinDieHandler>().AsSingle();

            Container.Bind<BEHealthData>().AsSingle();
        }
    }
}
