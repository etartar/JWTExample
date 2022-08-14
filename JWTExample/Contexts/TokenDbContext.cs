using JWTExample.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTExample.Contexts
{
    public class TokenDbContext : DbContext
    {
        public TokenDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("User");
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.RefreshToken).IsRequired(false);
            modelBuilder.Entity<User>().Property(x => x.RefreshTokenEndDate).IsRequired(false);
        }
    }
}
