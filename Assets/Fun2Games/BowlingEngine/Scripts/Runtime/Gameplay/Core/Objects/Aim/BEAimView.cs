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

        public (SplinePoint, int) LastPoint
        {
            get
            {
                var points = _spline.GetPoints();
                if (points != null && points.Length > 0)
                {
                    int index = points.Length - 1;
                    return (points[index], index);
                }
                return (new SplinePoint(), -1);
            }
        }

        public float LastPointXPosition
        {
            set
            {
                var (point, index) = LastPoint;
                if (index != -1)
                {
                    _spline.SetPointPosition(index, new Vector3(value, 0, point.position.z), SplineComputer.Space.Local);
                }
            }
        }

        public float SecondPointYPosition
        {
            set
            {
                var points = _spline.GetPoints();
                if (points.Length >= 2)
                {
                    var point = points[1];
                    _spline.SetPointPosition(1, new Vector3(0, value, point.position.z), SplineComputer.Space.Local);
                }
            }
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
