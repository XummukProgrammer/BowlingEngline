using System.Threading.Tasks;

namespace UnityGameTemplate.Resources.Interfaces
{
    public interface UGTIResource
    {
        public string ID { get; }
        public string Path { get; }

        public Task Load();
        public Task Unload();
    }
}
