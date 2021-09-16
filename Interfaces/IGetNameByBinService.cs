using System.Threading.Tasks;
using GarantsService.Models;

namespace GarantsService.Interfaces
{
    public interface IGetNameByBinService
    {
        public Task<LoanRequestModel> GateNameByBin(string bin);
    }
}