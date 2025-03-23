using UnityEngine;

namespace BowlingEngine.Services.ObjectsLoader
{
    public class ObjectsLoaderElement
    {
        public GameObject Prefab { get; private set; }
        public Transform Placeholder { get; private set; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public ObjectsLoaderElement(
            GameObject prefab,
            Transform placeholder,
            Vector3 position,
            Quaternion rotation)
        {
            Prefab = prefab;
            Placeholder = placeholder;
            Position = position;
            Rotation = rotation;
        }
    }
}
