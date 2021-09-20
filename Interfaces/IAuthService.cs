using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface IAuthService
    {
        public Task<UserModel> GetUserByUsername(string username);
        public Task<UserModel> GetUserById(int userId);
    }
}