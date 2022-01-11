using Microsoft.EntityFrameworkCore;
using Paylocity.DAL.Context;

namespace Paylocity.DAL
{
    public class PaylocityContext : DbContext
    {
        string _connectionString;

        public PaylocityContext(string connectionString)
        {
            _connectionString = !string.IsNullOrWhiteSpace(connectionString) ? connectionString : throw new ArgumentException(nameof(connectionString));
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, (c) => c.UseRelationalNulls());
        }

        public DbSet<EmployeeContext> Employee { get; set; }
    }
}