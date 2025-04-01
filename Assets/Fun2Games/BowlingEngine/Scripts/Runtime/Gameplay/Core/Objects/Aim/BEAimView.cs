using Dreamteck.Splines;
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

        public bool EnableRenderer
        {
            get => _meshRenderer.gameObject.activeSelf;
            set => _meshRenderer.gameObject.SetActive(value);
        }

        public SplineComputer Spline => _spline;

        [SerializeField]
        private SplineComputer _spline;

        [SerializeField]
        private MeshRenderer _meshRenderer;

        [Inject]
        public void Construct(BEAimFacade facade)
        {
            Facade = facade;
        }
    }
}
