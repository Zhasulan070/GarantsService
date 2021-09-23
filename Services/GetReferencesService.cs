using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class GetReferencesService: IGetReferencesService
    {
        private readonly DatabaseContext _context;

        public GetReferencesService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<FilialModel>> FilialsList()
        {
            return await _context.FilialModels.ToListAsync();
        }

        public async Task<List<CurrencyModel>> CurrencyList()
        {
            return await _context.CurrencyModels.ToListAsync();
        }

        public async Task<List<RequestTypeModel>> RequestTypeList()
        {
            return await _context.RequestTypeModels.ToListAsync();
        }
        
        public async Task<List<SegmentModel>> SegmentList()
        {
            return await _context.SegmentModels.ToListAsync();
        }
        
    }
}