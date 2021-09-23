using System.Threading.Tasks;

namespace GarantsService.Interfaces
{
    public interface ISaveFileService
    {
        public Task<bool> SaveFile(string orderId, string fileName, string filePath);
    }
}