using UnityGameTemplate.Common.States;
using UnityGameTemplate.Localizations.Models;
using UnityGameTemplate.Localizations.Services;
using UnityGameTemplate.Starter.Services;
using UnityGameTemplate.UI.Windows.Services;
using YG;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesLoad
        : UGTStatesLoad<UGTStarterStatesService, UGTStarterResourcesLoaderService, UGTStarterStatesGameplayLoad>
    {
        private readonly UGTLocalizationsService _localizationsService;

        public UGTStarterStatesLoad(
            UGTStarterStatesService statesService,
            UGTStarterResourcesLoaderService resourcesLoaderService, 
            UGTWindowContainerService windowContainerService,
            UGTLocalizationsService localizationsService) 
            : base(statesService, 
                  resourcesLoaderService, 
                  windowContainerService)
        {
            _localizationsService = localizationsService;
        }

        protected override bool CanStartLoad()
        {
            return YG2.isSDKEnabled;
        }

        protected override void OnBeforeLoad()
        {
            base.OnBeforeLoad();

            _localizationsService.LanguageType = UGTLanguageTypeExtension.FromStr(YG2.envir.language);
        }

        protected override void OnAfterLoad()
        {
        }
    }
}
