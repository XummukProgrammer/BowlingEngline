using System;
using UnityGameTemplate.UI.Windows.Models;
using UnityGameTemplate.UI.Windows.Views;
using Zenject;

namespace UnityGameTemplate.UI.Windows.Services
{
    public abstract class UGTWindowService
        : IInitializable
        , IDisposable
    {
        public string ID => Model.ID;
        public abstract UGTWindowModel Model { get; }
        public UGTWindowView View { set; get; }

        private readonly UGTWindowContainerService _containerService;

        public UGTWindowService(
            UGTWindowContainerService containerService)
        {
            _containerService = containerService;
        }

        public void Initialize()
        {
            _containerService.AddWindow(this);
        }

        public void Dispose()
        {
            _containerService.RemoveWindow(this);
        }

        public virtual void Show()
        {
            _containerService.CreateView(this);
        }

        public virtual void Close()
        {
            _containerService.RemoveView(this);
        }

        public virtual void OnViewInstantiate() 
        {
            View.CloseClicked += OnWindowClose;
        }

        public virtual void OnViewRemove() 
        {
            View.CloseClicked -= OnWindowClose;
        }

        protected virtual void OnWindowClose()
        {
            Close();
        }
    }
}
