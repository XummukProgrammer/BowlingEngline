using UnityEngine;
using Zenject;

namespace BowlingEngine.Common.UI.HUD.InfoHUD
{
    [CreateAssetMenu(fileName = "Info HUD Settings", menuName = "Bowling Engine/HUD/Info HUD")]
    public class BEInfoHUDSettings : ScriptableObjectInstaller<BEInfoHUDSettings>
    {
        [SerializeField]
        private BEInfoHUDModel _model;

        public override void InstallBindings()
        {
            Container.BindInstance(_model);
        }
    }
}
