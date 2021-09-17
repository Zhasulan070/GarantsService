using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class GetChecherService : IGetChecherService
    {
        private readonly DatabaseContext _context;

        public GetChecherService(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<CheckerModel>> GetCheckersList()
        {
            return await _context.CheckerModels.ToListAsync();
        }
    }
}