using UnityEngine;
using UnityGameTemplate.UI.HUD.Models;
using Zenject;

namespace UnityGameTemplate.UI.HUD.Settings
{
    public class UGTHUDSettings<T> : ScriptableObjectInstaller<UGTHUDSettings<T>>
        where T : UGTHUDModel
    {
        [SerializeField]
        private T _model;

        public override void InstallBindings()
        {
            Container.BindInstance(_model);
        }
    }
}
