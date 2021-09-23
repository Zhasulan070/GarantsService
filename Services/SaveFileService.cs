using System.Threading.Tasks;
using GarantsService.Context;
using GarantsService.Interfaces;
using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Services
{
    public class SaveFileService : ISaveFileService
    {
        private readonly DatabaseContext _context;

        public SaveFileService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<bool> SaveFile(string orderId, string fileName, string filePath)
        {
            _context.SaveFileModels.Add(new SaveFileModel
            {
                Name = fileName,
                OrderId = orderId,
                Path = filePath
            });
            return null;
        }
    }
}