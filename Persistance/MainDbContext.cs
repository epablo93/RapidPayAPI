using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Balance> Balance { get; set; }
    }
}
