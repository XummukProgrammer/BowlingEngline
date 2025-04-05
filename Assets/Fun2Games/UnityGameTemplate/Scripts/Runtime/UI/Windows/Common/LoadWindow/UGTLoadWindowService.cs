using UnityGameTemplate.Localizations.Services;
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
        private readonly UGTLocalizationsService _localizationsService;

        public UGTLoadWindowService(
            UGTWindowContainerService containerService,
            UGTLoadWindowModel model,
            UGTProjectModel projectModel,
            UGTLocalizationsService localizationsService) 
            : base(containerService)
        {
            _model = model;
            _projectModel = projectModel;
            _localizationsService = localizationsService;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            _localizationsService.LocalizeTextsUpdated += OnLocalizeTextsUpdated;
        }

        public override void OnClose()
        {
            _localizationsService.LocalizeTextsUpdated -= OnLocalizeTextsUpdated;

            base.OnClose();
        }

        public override void OnViewInstantiate()
        {
            base.OnViewInstantiate();

            var view = View as UGTLoadWindowView;
            view.GameName = _projectModel.Name;
            view.Version = _projectModel.FullVersion;
            view.CompanyName = "Fun2Games";

            UpdateTexts();
        }

        private void OnLocalizeTextsUpdated()
        {
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            var view = View as UGTLoadWindowView;

            view.Description = _localizationsService.GetLocalizeText(
                _model.DescriptionLocalizationID, 
                view.Description);
        }
    }
}
