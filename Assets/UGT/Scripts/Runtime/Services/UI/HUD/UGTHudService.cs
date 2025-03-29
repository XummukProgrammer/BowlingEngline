using UGT.Services.UI.Models;
using Zenject;

namespace UGT.Services.UI.HUD
{
    public abstract class UGTHudService : IInitializable
    {
        public abstract UGTHudModel Model { get; }
        public UGTHudView View { get; set; }

        protected abstract UGTHudService This { get; }

        private readonly UGTHudContainerService _hudContainerService;

        public UGTHudService(UGTHudContainerService hudContainerService)
        {
            _hudContainerService = hudContainerService;
        }

        public void Initialize()
        {
            _hudContainerService.Add(This);
        }

        public virtual void OnInstantiate() 
        {
            View.Clicked += OnClicked;
        }

        public virtual void OnDestroy()
        {
            View.Clicked -= OnClicked;
        }

        protected virtual void OnClicked()
        {
        }
    }
}
