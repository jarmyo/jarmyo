namespace Personal.Models.School
{
    public class SchoolAdminModel
    {
        public SchoolAdminModel() {
            Clients = new List<Client>();
            Services = new List<Service>();            
        }
        public List<Client> Clients { get; set; }
        public List<Service> Services { get; set; }        
    }
}