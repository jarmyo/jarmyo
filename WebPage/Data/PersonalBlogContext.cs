using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace Personal.Data
{
    public class PersonalBlogContext : DbContext
    {
        public DbSet<Post> Entradas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"wwwroot\data\personalblog.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}