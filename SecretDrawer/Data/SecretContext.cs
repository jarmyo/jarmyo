global using System.ComponentModel.DataAnnotations;
global using Microsoft.Data.Sqlite;
global using Microsoft.EntityFrameworkCore;

namespace SecretDrawer.Data
{
    public class SecretContext : DbContext
    {
        public DbSet<Secret>? Secrets{ get; set; }
        public DbSet<Category>? Categories { get; set; }     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"Data\Secrets.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   
            //modelBuilder.Entity<PostTags>()
            //    .HasKey(o => new { o.IdPost, o.Tag });
        }
    }
}