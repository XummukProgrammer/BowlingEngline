using UnityEngine;
using Zenject;

namespace BowlingEngine.Gameplay.Core.Objects.Aim
{
    public class BEAimView : MonoBehaviour
    {
        public BEAimFacade Facade { get; private set; }

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Quaternion
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        [Inject]
        public void Construct(BEAimFacade facade)
        {
            Facade = facade;
        }
    }
}
