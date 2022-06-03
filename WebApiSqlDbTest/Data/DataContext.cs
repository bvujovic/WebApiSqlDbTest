using Microsoft.EntityFrameworkCore;

namespace WebApiSqlDbTest.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ClassLib.Target> Targets { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Data/test.db");

            //dotnet ef migrations add CreateInitial
            //dotnet ef database update

        }
    }
}
