using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace UGT.Services.UI.HUD
{
    public class UGTHudContainerService : IInitializable
    {
        private UGTHudContainerView _containerView;
        private Dictionary<string, UGTHudService> _huds = new();

        public void Initialize()
        {
            _containerView = GameObject.FindFirstObjectByType<UGTHudContainerView>();
        }

        public void Add<T>(T hudService) where T : UGTHudService
        {
            _huds.Add(hudService.GetType().Name, hudService);
        }

        public async Task CreateAll()
        {
            foreach (var hud in _huds.Values)
            {
                var view = await _containerView.Create(hud.Model.Location, hud.Model.Prefab);
                hud.View = view;
                hud.OnInstantiate();
            }
        }

        public void UnloadAll()
        {
            foreach (var hud in _huds.Values)
            {
                hud.OnDestroy();
                GameObject.Destroy(hud.View.gameObject);
            }

            _huds.Clear();
        }
    }
}
