using System.Collections.Generic;
using System.Threading.Tasks;
using UGT.Services.Resources.Interfaces;
using UGT.Services.Resources.Models;
using Unity.VisualScripting;
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
                var hashCode = resource.GetHashCode().ToString();
                if (!string.IsNullOrEmpty(hashCode))
                {
                    if (!_resources.ContainsKey(hashCode))
                    {
                        var instance = resource.Instance;
                        await instance.Load();

                        _resources.Add(hashCode, instance);

                        Debug.Log($"Added a new resource (HashCode: {hashCode}, Type: {instance.GetType().Name}, Path: {resource.Path}).");
                    }
                }
            }
        }

        public async Task Unload(UGTResourcesModel resourcesModel)
        {
            var resourcesToRemove = new List<string>();

            foreach (var resource in resourcesModel.Resources)
            {
                var hashCode = resource.GetHashCode().ToString();
                if (!string.IsNullOrEmpty(hashCode))
                {
                    if (_resources.TryGetValue(hashCode, out var instance))
                    {
                        resourcesToRemove.Add(hashCode);

                        await instance.Unload();

                        Debug.Log($"Resource deleted (HashCode: {hashCode}).");
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
