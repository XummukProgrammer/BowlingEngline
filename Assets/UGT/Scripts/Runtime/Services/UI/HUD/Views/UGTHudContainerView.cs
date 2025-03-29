using System.Linq;
using System.Threading.Tasks;
using UGT.Services.UI.Models;
using UnityEngine;
namespace UGT.Services.UI.HUD
{
    public class UGTHudContainerView : MonoBehaviour
    {
        [SerializeField]
        private UGTHudContainerElementModel[] _elements;

        public async Task<UGTHudView> Create(UGTHudLocation location, UGTHudView prefab)
        {
            var element = _elements.FirstOrDefault(e => e.Location == location);
            if (element != null)
            {
                var objects = await InstantiateAsync(prefab, element.Transform);
                if (objects.Length > 0)
                {
                    return objects[0];
                }
            }
            return null;
        }
    }
}
