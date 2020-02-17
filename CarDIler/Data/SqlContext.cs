using CarDIler.Data.Models.Car;
using CarDIler.Data.Models.Post;
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
        public DbSet<Post> Posts { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        public SqlContext() { }
    }
}
