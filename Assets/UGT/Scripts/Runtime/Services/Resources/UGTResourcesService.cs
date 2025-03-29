using System.Collections.Generic;
using System.Threading.Tasks;
using UGT.Services.Localizations;
using UGT.Services.Resources.Interfaces;
using UGT.Services.Resources.Models;
using UnityEngine;

namespace UGT.Services.Resources
{
    public class UGTResourcesService
    {
        private Dictionary<string, UGTIResource> _resources = new();

        private readonly UGTLocalizationsService _localizationsService;

        public UGTResourcesService(UGTLocalizationsService localizationsService)
        {
            _localizationsService = localizationsService;
        }

        public async Task Load(UGTResourcesModel resourcesModel)
        {
            foreach (var resource in resourcesModel.Resources)
            {
                if (!_resources.ContainsKey(resource.Path))
                {
                    var instance = resource.CreateInstance(CreateDependenciesModel(resource.Dependencies));
                    await instance.Load();

                    _resources.Add(resource.Path, instance);

                    Debug.Log($"Added a new resource (Type: {instance.GetType().Name}, Path: {resource.Path}).");
                }
            }
        }

        public async Task Unload(UGTResourcesModel resourcesModel)
        {
            var resourcesToRemove = new List<string>();

            foreach (var resource in resourcesModel.Resources)
            {
                if (_resources.TryGetValue(resource.Path, out var instance))
                {
                    resourcesToRemove.Add(resource.Path);

                    await instance.Unload();

                    Debug.Log($"Resource deleted (Path: {resource.Path}).");
                }
            }

            foreach (var path in resourcesToRemove)
            {
                _resources.Remove(path);
            }
        }

        private UGTResourceDependenciesModel CreateDependenciesModel(UGTResourceDependencyType[] dependencies)
        {
            var dependenciesModel = new UGTResourceDependenciesModel();
            foreach (var dependency in dependencies)
            {
                if (dependency == UGTResourceDependencyType.Localizations)
                {
                    dependenciesModel.Localizations = _localizationsService;
                }
            }
            return dependenciesModel;
        }
    }
}
