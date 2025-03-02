using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cart > Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
