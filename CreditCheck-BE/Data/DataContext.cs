using CreditCheck_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCheck_BE.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ScoreQuery> ScoreQueries { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
