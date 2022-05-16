namespace Personal.Models.School
{
    public class SchoolIndexModel
    {
        public SchoolIndexModel() { }
    }
    public class SchoolAdminModel
    {
        public SchoolAdminModel() {
            Clients = new List<Client>();
            Services = new List<Service>();
            Appointments = new List<Appointment>();
        }
        public List<Client> Clients { get; set; }
        public List<Service> Services { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}