using UnityEngine;

namespace UnityGameTemplate.UI.Windows.Views
{
    public class UGTWindowContainerView : MonoBehaviour
    {
        [SerializeField]
        private Transform _content;

        public UGTWindowView CreateView(UGTWindowView prefab)
        {
            return Instantiate(prefab, _content);
        }
    }
}
