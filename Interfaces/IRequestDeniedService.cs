using System.Threading.Tasks;

namespace GarantsService.Interfaces
{
    public interface IRequestDeniedService
    {
        Task<string> RequestDenied();
    }
}