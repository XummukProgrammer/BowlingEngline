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

            OnCreate();
        }

        public void Dispose()
        {
            _containerService.RemoveWindow(this);
        }

        public virtual void Show()
        {
            _containerService.CreateView(this);
        }

        public virtual void OnCreate()
        {
        }

        public virtual void OnClose()
        {
            _containerService.RemoveView(this);
        }

        public virtual void OnViewInstantiate() 
        {
            View.CloseClicked += OnCloseClicked;
        }

        public virtual void OnViewRemove() 
        {
            View.CloseClicked -= OnCloseClicked;
        }

        protected virtual void OnCloseClicked()
        {
            OnClose();
        }
    }
}
