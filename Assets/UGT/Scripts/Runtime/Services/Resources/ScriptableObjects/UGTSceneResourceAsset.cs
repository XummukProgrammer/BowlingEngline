using UGT.Services.Resources.Interfaces;
using UGT.Services.Resources.Models;
using UnityEngine;

namespace UGT.Services.Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Scene Asset", menuName = "UGT/Assets/Resources/Scene", order = 2)]
    public class UGTSceneResourceAsset : UGTResourceAsset
    {
        public override UGTResourceDependencyType[] Dependencies => new UGTResourceDependencyType[] { };

        public override UGTIResource CreateInstance(UGTResourceDependenciesModel dependencies)
        {
            return new UGTSceneResource(Path);
        }
    }
}
