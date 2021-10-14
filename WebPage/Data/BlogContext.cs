using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace Personal.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Entradas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"wwwroot\data\blog.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}