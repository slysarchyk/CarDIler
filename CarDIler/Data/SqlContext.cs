using CarDIler.Data.Models.Car;
using CarDIler.Data.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarDIler.Models
{
    public class SqlContext : IdentityDbContext<User>
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Year> Years { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public SqlContext() { }
    }
}
