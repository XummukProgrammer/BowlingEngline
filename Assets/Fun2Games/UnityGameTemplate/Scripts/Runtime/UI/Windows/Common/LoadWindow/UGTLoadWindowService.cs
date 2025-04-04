using UnityGameTemplate.UI.Windows.Models;
using UnityGameTemplate.UI.Windows.Services;

namespace UnityGameTemplate.UI.Windows.Common.LoadWindow
{
    public class UGTLoadWindowService : UGTWindowService
    {
        public override UGTWindowModel Model => _model;

        private readonly UGTLoadWindowModel _model;

        public UGTLoadWindowService(
            UGTWindowContainerService containerService,
            UGTLoadWindowModel model) 
            : base(containerService)
        {
            _model = model;
        }
    }
}
