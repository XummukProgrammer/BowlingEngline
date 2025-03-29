using UGT.Services.UI.Models;
using UnityEngine;
using Zenject;

namespace UGT.Services.UI.HUD.Installers
{
    public class UGTHudAssetInstaller<T> : ScriptableObjectInstaller<UGTHudAssetInstaller<T>> where T : UGTHudModel
    {
        [SerializeField]
        private T _model;

        public override void InstallBindings()
        {
            Container.BindInstance(_model);
        }
    }
}
