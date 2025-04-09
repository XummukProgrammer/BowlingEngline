using System;
using UnityGameTemplate.UI.HUD.Models;
using UnityGameTemplate.UI.HUD.Views;
using Zenject;

namespace UnityGameTemplate.UI.HUD.Services
{
    public abstract class UGTHUDService 
        : IInitializable
        , IDisposable
        , ITickable
    {
        public abstract UGTHUDModel Model { get; }
        public UGTHUDView View { get; set; }

        private readonly UGTHUDContainerService _hudContainerService;
        private bool _isShowed;

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

        public void Tick()
        {
            if (!_isShowed && IsActive())
            {
                Show();
            }
            else if (_isShowed && !IsActive())
            {
                Close();
            }
        }

        public void Show()
        {
            _isShowed = true;

            _hudContainerService.CreateView(this);
            OnCreate();
        }

        public void Close()
        {
            _isShowed = false;

            _hudContainerService.RemoveView(this);
            OnClose();
        }

        protected virtual bool IsActive()
        {
            return true;
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
