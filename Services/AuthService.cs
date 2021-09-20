using System.Linq;
using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _context;

        public AuthService(DatabaseContext context)
        {
            _context = context;
        }


        public async Task<UserModel> GetUserByUsername(string username)
        {
            return await _context.UserModels.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            return await _context.UserModels.FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}