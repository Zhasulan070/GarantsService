using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface IGetReferencesService
    {
        public Task<List<FilialModel>> FilialsList();
        public Task<List<CurrencyModel>> CurrencyList();
        public Task<List<RequestTypeModel>> RequestTypeList();
        public Task<List<SegmentModel>> SegmentList();
    }
}