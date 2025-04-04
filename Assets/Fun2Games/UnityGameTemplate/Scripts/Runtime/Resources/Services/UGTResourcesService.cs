using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityGameTemplate.Resources.Factories;
using UnityGameTemplate.Resources.Implementation;
using UnityGameTemplate.Resources.Interfaces;
using UnityGameTemplate.Resources.Models;

namespace UnityGameTemplate.Resources.Services
{
    public class UGTResourcesService
    {
        private Dictionary<string, UGTIResource> _resources = new();

        private readonly UGTResourcesFactory _factory;

        public UGTResourcesService(UGTResourcesFactory factory)
        {
            _factory = factory;
        }

        public async Task Load(UGTResourcesModel resourcesModel)
        {
            foreach (var resourceModel in resourcesModel.Resources)
            {
                await Load(resourceModel);
            }
        }

        public async Task Load(UGTResourceModel resourceModel)
        {
            var resource = _factory.Create(resourceModel);
            if (resource != null)
            {
                await resource.Load();
                Debug.Log($"The {resource.ID} resource has been loaded (Path: {resource.Path}, Type: {resourceModel.Type}).");

                _resources.Add(resource.ID, resource);
            }
        }

        public async Task Unload(UGTResourcesModel resourcesModel)
        {
            var resourcesToRemove = new List<string>();

            foreach (var resourceModel in resourcesModel.Resources)
            {
                if (await Unload(resourceModel))
                {
                    resourcesToRemove.Add(resourceModel.ID);
                }
            }

            foreach (var resourceID in resourcesToRemove)
            {
                _resources.Remove(resourceID);
            }
        }

        public async Task<bool> Unload(UGTResourceModel resourceModel, bool removeFromDictionary = false)
        {
            if (_resources.TryGetValue(resourceModel.ID, out var resource))
            {
                await resource.Unload();
                Debug.Log($"The {resource.ID} resource has been deleted (Path: {resource.Path}, Type: {resourceModel.Type}).");

                if (removeFromDictionary)
                {
                    _resources.Remove(resource.ID);
                }

                return true;
            }

            return false;
        }

        public UGTIResource Find(string id)
        {
            if (_resources.TryGetValue(id, out var resource))
            {
                return resource;
            }
            return null;
        }

        public UGTCommonResource<T> FindCommon<T>(string id)
        {
            var resource = Find(id);
            if (resource != null)
            {
                return resource as UGTCommonResource<T>;
            }
            return null;
        }
    }
}
