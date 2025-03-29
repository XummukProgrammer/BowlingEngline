using System.Threading.Tasks;
using UGT.Services.Localizations.Models;
using UGT.Services.Resources.Interfaces;

namespace UGT.Services.Localizations
{
    public class UGTLocalizationsResource : UGTIResource
    {
        private readonly UGTLocalizationsService _localizationsService;
        private readonly UGTLocalizationModel _model;

        public UGTLocalizationsResource(
            UGTLocalizationsService localizationsService, 
            UGTLocalizationModel model)
        {
            _localizationsService = localizationsService;
            _model = model;
        }

        public async Task Load()
        {
            _localizationsService.LoadLocalizeData(_model);
        }

        public async Task Unload()
        {
            _localizationsService.UnloadLocalizeData(_model);
        }
    }
}
