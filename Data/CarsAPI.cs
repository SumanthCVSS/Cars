using Cars.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data
{
    public class CarsAPI : IdentityDbContext<IdentityUser>
    {
        public CarsAPI() { }
        public CarsAPI(DbContextOptions options) : base(options) { }
             

        public DbSet<Car> Cars{ get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
