using ClassLib;
using Microsoft.EntityFrameworkCore;

namespace WebApiSqlDbTest.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Target> Targets { get; set; } = default!;

        public DbSet<User> Users { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Data/test.db");

            //dotnet ef migrations add CreateInitial
            // Add-Migration InitialCreate
            //dotnet ef database update
            // Update-Database
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasMany(u => u.OwnedTargets).WithOne(t => t.UserOwner);
            builder.Entity<User>().HasMany(u => u.ModifiedTargets).WithOne(t => t.UserModified);
            builder.Entity<User>().HasMany(u => u.AccessedTargets).WithOne(t => t.UserAccessed);
        }
    }
}
