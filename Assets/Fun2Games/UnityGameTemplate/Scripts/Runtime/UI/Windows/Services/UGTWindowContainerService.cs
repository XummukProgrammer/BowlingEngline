using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGameTemplate.UI.Windows.Views;
using Zenject;

namespace UnityGameTemplate.UI.Windows.Services
{
    public class UGTWindowContainerService
        : IInitializable
    {
        private UGTWindowContainerView _containerView;
        private List<UGTWindowService> _windows = new();

        public void Initialize()
        {
            _containerView = GameObject.FindFirstObjectByType<UGTWindowContainerView>();
        }

        public void AddWindow(UGTWindowService window)
        {
            _windows.Add(window);
        }

        public void RemoveWindow(UGTWindowService window)
        {
            _windows.Remove(window);
        }

        public UGTWindowService GetWindow(string id)
        {
            return _windows.FirstOrDefault(w => w.ID == id);
        }

        public void CreateView(UGTWindowService window)
        {
            if (window.View == null)
            {
                var view = _containerView.CreateView(window.Model.Prefab);
                window.View = view;
                window.OnViewInstantiate();
            }
        }

        public void RemoveView(UGTWindowService window)
        {
            if (window.View != null)
            {
                window.OnViewRemove();

                GameObject.Destroy(window.View.gameObject);

                window.View = null;
            }
        }

        public void ShowWindow(string id)
        {
            var window = GetWindow(id);
            window?.Show();
        }

        public void CloseWindow(string id)
        {
            var window = GetWindow(id);
            window?.OnClose();
        }
    }
}
