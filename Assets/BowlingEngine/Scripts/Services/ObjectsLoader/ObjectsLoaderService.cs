using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace BowlingEngine.Services.ObjectsLoader
{
    public class ObjectsLoaderService
    {
        public event System.Action<int> DownloadStarted;
        public event System.Action DownloadFinished;

        public event System.Action<int> ItemLoaded;

        public async Task<GameObject> Load(ObjectsLoaderElement element)
        {
            var objects = await GameObject.InstantiateAsync(
                element.Prefab, 
                element.Placeholder, 
                element.Position, 
                element.Rotation);

            if (objects.Length > 0)
                return objects[0];

            return null;
        }

        public async Task<List<GameObject>> LoadElements(IEnumerable<ObjectsLoaderElement> elements)
        {
            DownloadStarted?.Invoke(elements.Count());

            var list = new List<GameObject>();
            int index = 0;
            foreach (var element in elements)
            {
                await Load(element);
                ItemLoaded?.Invoke(index);
                index++;
            }

            DownloadFinished?.Invoke();

            return list;
        }
    }
}
