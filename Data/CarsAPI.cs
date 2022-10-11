using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsAPI : DbContext
    {
        public CarsAPI(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars{ get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
