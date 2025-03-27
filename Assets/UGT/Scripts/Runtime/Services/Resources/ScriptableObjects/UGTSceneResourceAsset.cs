using UGT.Services.Resources.Interfaces;
using UnityEngine;

namespace UGT.Services.Resources.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Scene Asset", menuName = "UGT/Assets/Resources/Scene", order = 2)]
    public class UGTSceneResourceAsset : UGTResourceAsset
    {
        public override UGTIResource Instance => new UGTSceneResource(Path);
    }
}
