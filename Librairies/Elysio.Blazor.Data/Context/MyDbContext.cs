
using Elysio.Blazor.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Elysio.Blazor.Data.Context
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        // Utilisé par l’implémentation de IDesignTimeDbContextFactory
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        #region DbSets
        public DbSet<Article> Articles { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
