using System.Collections.Generic;
using UnityEngine;
using UnityGameTemplate.UI.HUD.Views;
using Zenject;

namespace UnityGameTemplate.UI.HUD.Services
{
    public class UGTHUDContainerService : IInitializable
    {
        private UGTHUDContainerView _containerView;
        private List<UGTHUDService> _services = new();

        public void Initialize()
        {
            _containerView = GameObject.FindFirstObjectByType<UGTHUDContainerView>();
        }

        public void RegisterService(UGTHUDService hudService)
        {
            _services.Add(hudService);
        }

        public void UnregisterService(UGTHUDService hudService)
        {
            _services.Remove(hudService);
        }

        public void CreateView(UGTHUDService hudService)
        {
            if (hudService.View == null)
            {
                hudService.View = _containerView.CreateView(hudService.Model.Prefab, hudService.Model.PlaceType);
                hudService.OnViewInstantiate();
            }
        }

        public void RemoveView(UGTHUDService hudService)
        {
            if (hudService.View != null)
            {
                hudService.OnViewRemove();
                GameObject.Destroy(hudService.View.gameObject);
            }
        }
    }
}
