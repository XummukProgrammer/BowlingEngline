using UnityGameTemplate.Starter.Models;
using UnityGameTemplate.UI.Windows.Models;
using UnityGameTemplate.UI.Windows.Services;

namespace UnityGameTemplate.UI.Windows.Common.LoadWindow
{
    public class UGTLoadWindowService : UGTWindowService
    {
        public override UGTWindowModel Model => _model;

        private readonly UGTLoadWindowModel _model;
        private readonly UGTProjectModel _projectModel;

        public UGTLoadWindowService(
            UGTWindowContainerService containerService,
            UGTLoadWindowModel model,
            UGTProjectModel projectModel) 
            : base(containerService)
        {
            _model = model;
            _projectModel = projectModel;
        }

        public override void OnViewInstantiate()
        {
            base.OnViewInstantiate();

            var view = View as UGTLoadWindowView;
            view.GameName = _projectModel.Name;
            view.Version = _projectModel.FullVersion;
            view.CompanyName = "Fun2Games";
        }
    }
}
