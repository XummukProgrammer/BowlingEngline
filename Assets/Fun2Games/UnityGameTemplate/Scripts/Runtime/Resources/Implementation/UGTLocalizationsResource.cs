using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityGameTemplate.Localizations.Models;
using UnityGameTemplate.Localizations.ScriptableObjects;
using UnityGameTemplate.Localizations.Services;

namespace UnityGameTemplate.Resources.Implementation
{
    public class UGTLocalizationsResource : UGTCommonResource<UGTLocalizedResourceSO>
    {
        private readonly UGTLocalizationsService _localizationsService;
        private AsyncOperationHandle<UGTLocalizedLanguageSO> _handler;

        public UGTLocalizationsResource(
            string id, 
            string path,
            UGTLocalizationsService localizationsService) 
            : base(id, path)
        {
            _localizationsService = localizationsService;
        }

        protected override async Task OnLoaded()
        {
            await base.OnLoaded();

            var resource = Result.GetResource(_localizationsService.LanguageType);
            _handler = Addressables.LoadAssetAsync<UGTLocalizedLanguageSO>(resource.ResourceID);

            await _handler.Task;

            if (_handler.Status == AsyncOperationStatus.Succeeded)
            {
                _localizationsService.Load(_handler.Result);
            }
        }

        protected override async Task OnUnloaded()
        {
            await base.OnUnloaded();

            _localizationsService.Unload(_handler.Result);
        }
    }
}
