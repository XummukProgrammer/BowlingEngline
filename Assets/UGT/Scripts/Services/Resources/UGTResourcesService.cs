using System.Collections.Generic;
using System.Threading.Tasks;
using UGT.Services.Resources.Interfaces;
using UGT.Services.Resources.Models;
using UnityEditor;
using UnityEngine;

namespace UGT.Services.Resources
{
    public class UGTResourcesService
    {
        private Dictionary<string, UGTIResource> _resources = new();

        public async Task Load(UGTResourcesModel resourcesModel)
        {
            foreach (var resource in resourcesModel.Resources)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(resource, out var guid, out _))
                {
                    if (!_resources.ContainsKey(guid))
                    {
                        var instance = resource.Instance;
                        await instance.Load();

                        _resources.Add(guid, instance);

                        Debug.Log($"Added a new resource (GUID: {guid}, Type: {instance.GetType().Name}, Path: {resource.Path}).");
                    }
                }
            }
        }

        public async Task Unload(UGTResourcesModel resourcesModel)
        {
            var resourcesToRemove = new List<string>();

            foreach (var resource in resourcesModel.Resources)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(resource, out var guid, out _))
                {
                    if (_resources.TryGetValue(guid, out var instance))
                    {
                        resourcesToRemove.Add(guid);

                        await instance.Unload();

                        Debug.Log($"Resource deleted (GUID: {guid}).");
                    }
                }
            }

            foreach (var guid in resourcesToRemove)
            {
                _resources.Remove(guid);
            }
        }
    }
}
