using UnityGameTemplate.Localizations.Services;
using UnityGameTemplate.Resources.Implementation;
using UnityGameTemplate.Resources.Interfaces;
using UnityGameTemplate.Resources.Models;
using Zenject;

namespace UnityGameTemplate.Resources.Factories
{
    public class UGTResourcesFactory : IInitializable
    {
        private UGTLocalizationsService _localizationsService;

        private readonly DiContainer _diContainer;

        public UGTResourcesFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            _localizationsService = _diContainer.Resolve<UGTLocalizationsService>();
        }

        public UGTIResource Create(UGTResourceModel resourceModel)
        {
            switch (resourceModel.Type)
            {
                case UGTResourceType.Scene:
                    return new UGTSceneResource(resourceModel.ID, resourceModel.Path);

                case UGTResourceType.LocalizeText:
                    return new UGTLocalizationsResource(resourceModel.ID, resourceModel.Path, _localizationsService);
            }
            return null;
        }
    }
}
