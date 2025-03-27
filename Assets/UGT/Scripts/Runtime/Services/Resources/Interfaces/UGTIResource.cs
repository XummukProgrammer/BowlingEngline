using System.Threading.Tasks;

namespace UGT.Services.Resources.Interfaces
{
    public interface UGTIResource
    {
        public Task Load();
        public Task Unload();
    }
}
