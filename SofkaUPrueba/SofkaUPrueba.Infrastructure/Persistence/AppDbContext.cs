using Microsoft.EntityFrameworkCore;
using SofkaUPrueba.Core.Entities;
using SofkaUPrueba.Infrastructure.Persistence.Configurations;
using System.Reflection;

namespace SofkaUPrueba.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Players> Players { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Questions> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ApplyConfiguration(new PlayersConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
