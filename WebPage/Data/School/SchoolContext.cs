namespace Personal.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Configs> Configurations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAppointment> ClientAppointments { get; set; }
        public DbSet<Business> Businesses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = @"Data\store\school.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   
            modelBuilder.Entity<ClientAppointment>()
                .HasKey(o => new { o.IdClient, o.IdAppointment });
        }
    }
}