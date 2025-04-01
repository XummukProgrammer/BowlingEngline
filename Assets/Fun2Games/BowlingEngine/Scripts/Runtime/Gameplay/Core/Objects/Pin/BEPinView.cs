using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinView : MonoBehaviour
    {
        public BEPinFacade Facade { get; private set; }

        [Inject]
        public void Construct(BEPinFacade facade)
        {
            Facade = facade;
        }
    }
}
