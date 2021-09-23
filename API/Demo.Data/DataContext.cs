using Demo.Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base() { }

        public DbSet<StockItem> StockItems { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<StockItemUnit> StockItemUnits { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=EFLab;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
