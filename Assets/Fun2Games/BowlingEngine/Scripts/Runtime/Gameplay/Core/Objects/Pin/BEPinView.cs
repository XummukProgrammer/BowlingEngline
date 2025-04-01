using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Pin
{
    public class BEPinView : MonoBehaviour
    {
        [Inject]
        public BEPinFacade Facade { get; set; }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}
