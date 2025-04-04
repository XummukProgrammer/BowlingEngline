using UnityEngine;
using UnityGameTemplate.UI.Windows.Models;
using Zenject;

namespace UnityGameTemplate.UI.Windows.Settings
{
    public class UGTWindowSettings<T> 
        : ScriptableObjectInstaller<UGTWindowSettings<T>>
        where T : UGTWindowModel
    {
        [SerializeField]
        private T _model;

        public override void InstallBindings()
        {
            Container.BindInstance(_model);
        }
    }
}
