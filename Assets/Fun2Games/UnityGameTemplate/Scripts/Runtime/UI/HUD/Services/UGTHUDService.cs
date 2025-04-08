using System;
using UnityGameTemplate.UI.HUD.Models;
using UnityGameTemplate.UI.HUD.Views;
using Zenject;

namespace UnityGameTemplate.UI.HUD.Services
{
    public abstract class UGTHUDService 
        : IInitializable
        , IDisposable
    {
        public abstract UGTHUDModel Model { get; }
        public UGTHUDView View { get; set; }

        private readonly UGTHUDContainerService _hudContainerService;

        public UGTHUDService(UGTHUDContainerService hudContainerService)
        {
            _hudContainerService = hudContainerService;
        }

        public void Initialize()
        {
            _hudContainerService.RegisterService(this);
        }

        public void Dispose()
        {
            _hudContainerService.UnregisterService(this);
        }

        public void Show()
        {
            _hudContainerService.CreateView(this);
            OnCreate();
        }

        public void Close()
        {
            _hudContainerService.RemoveView(this);
            OnClose();
        }

        public virtual void OnViewInstantiate() 
        {
            View.Clicked += OnClicked;
        }

        public virtual void OnViewRemove() 
        {
            View.Clicked -= OnClicked;
        }

        protected virtual void OnCreate() { }
        protected virtual void OnClose() { }

        protected virtual void OnClicked() { }
    }
}
