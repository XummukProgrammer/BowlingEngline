using UGT.Basic.Data;
using UGT.Basic.Models;
using UGT.Services.Localizations;
using UGT.Services.Localizations.Models;
using UGT.Services.StatesMachine.Interfaces;
using UnityEngine;
using YG;

namespace UGT.Basic.Services.StatesMachine
{
    public class UGTBasicBoostrapState 
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTBasicStatesMachineService _statesMachineService;
        private readonly UGTBasicModel _basicModel;
        private readonly UGTBasicData _basicData;
        private readonly UGTLocalizationsService _localizationsService;

        public UGTBasicBoostrapState(
            UGTBasicStatesMachineService statesMachineService,
            UGTBasicModel basicModel,
            UGTBasicData basicData,
            UGTLocalizationsService localizationsService)
        {
            _statesMachineService = statesMachineService;
            _basicModel = basicModel;
            _basicData = basicData;
            _localizationsService = localizationsService;
        }

        public void Enter()
        {
            Debug.Log("UGTBasicBoostrapState.Enter");

            YG2.onGetSDKData += OnLoaded;

            if (YG2.isSDKEnabled)
            {
                OnLoaded();
            }
        }

        public void Exit()
        {
            Debug.Log("UGTBasicBoostrapState.Exit");

            YG2.onGetSDKData -= OnLoaded;
        }

        private void OnLoaded()
        {
            var language = UGTLanguageTypeExtension.FromServerString(YG2.envir.language);
            _localizationsService.SetCurrentLanguage(language);

            _basicData.GameplayType = _basicModel.DefaultGameplayType;

            _statesMachineService.EnterState<UGTBasicGameplayLoadState>();
        }
    }
}
