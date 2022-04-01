namespace Personal.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Entradas { get; set; }
        public DbSet<Tag> Etiquetas { get; set; }
        public DbSet<PostTags> EtiquetasEntradas { get; set; }
        public DbSet<MonthYear> Fechas { get; set; }
        public DbSet<PostMonthYear> FechasEntradas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"wwwroot\data\blog.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   
            modelBuilder.Entity<PostTags>()
                .HasKey(o => new { o.IdPost, o.Tag });
        }
    }
}