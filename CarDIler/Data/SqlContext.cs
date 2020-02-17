using CarDIler.Data.Models;
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
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        public SqlContext() { }
    }
}
