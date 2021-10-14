using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace Personal.Data
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Visitante> Visitantes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"wwwroot\data\SQLite.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}