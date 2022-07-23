using Microsoft.EntityFrameworkCore;
using OrderBook.Models;

namespace OrderBook.DBRealization
{
    public class DataContext : DbContext
    {
        private readonly string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=ordersdb;Trusted_Connection=True;";

        public DbSet<Order>? Orders { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}