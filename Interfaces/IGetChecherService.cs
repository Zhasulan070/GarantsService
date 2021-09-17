using System.Collections.Generic;
using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface IGetChecherService
    {
        public Task<List<CheckerModel>> GetCheckersList();
    }
}