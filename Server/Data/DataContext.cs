using blazor_wasm_sql_db.Client.Shared;
using Microsoft.EntityFrameworkCore;

namespace blazor_was_sql_db.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
