using System.Linq;
using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class GetNameByBinService : IGetNameByBinService
    {
        private readonly DatabaseContext _context;

        public GetNameByBinService(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<LoanRequestModel> GateNameByBin(string bin)
        {
            var res = await _context.LoanRequestModels.FirstOrDefaultAsync(x=>x.Bin == bin);
            return res;
        }
    }
}