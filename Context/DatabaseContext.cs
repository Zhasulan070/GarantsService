using GarantsService.Models;
using Microsoft.EntityFrameworkCore;

namespace GarantsService.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        

        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<OrderModelWithKl> OrderModelWithKl { get; set; }
        public DbSet<OrderDetailModel> OrderDetailModels { get; set; }
        public DbSet<FilialModel> FilialModels { get; set; }
        public DbSet<CurrencyModel> CurrencyModels { get; set; }
        public DbSet<RequestTypeModel> RequestTypeModels { get; set; }
        public DbSet<LoanRequestModel> LoanRequestModels { get; set; }
        public DbSet<CheckerModel> CheckerModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<SegmentModel> SegmentModels { get; set; }
        public DbSet<SaveFileModel> SaveFileModels { get; set; } 
    }
}