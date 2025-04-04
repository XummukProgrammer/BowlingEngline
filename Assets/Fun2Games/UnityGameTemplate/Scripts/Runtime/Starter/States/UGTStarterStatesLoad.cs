using System.Threading.Tasks;
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
        private bool _asyncLoadEnabled = false;

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

        protected override void OnAfterLoad()
        {
        }

        protected override void OnChangeState()
        {
            if (YG2.isSDKEnabled)
            {
                ChangeState();
            }
            else
            {
                _asyncLoadEnabled = true;

                YG2.onGetSDKData += ChangeState;
            }
        }

        private void ChangeState()
        {
            if (_asyncLoadEnabled)
            {
                _asyncLoadEnabled = false;

                YG2.onGetSDKData -= ChangeState;
            }

            _localizationsService.LanguageType = UGTLanguageTypeExtension.FromStr(YG2.envir.language);

            _statesService.EnterState<UGTStarterStatesGameplayLoad>();
        }
    }
}
