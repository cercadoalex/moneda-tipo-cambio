using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<Divisa> Divisas { get; set; }
        public DbSet<TablaConversion> TablaConversions   { get; set; }

    }
}
