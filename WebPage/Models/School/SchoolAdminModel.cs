namespace Personal.Models.School
{
    public class SchoolAdminModel
    {
        public SchoolAdminModel() {
            Clients = [];
            Services = [];            
        }
        public List<Client> Clients { get; set; }
        public List<Service> Services { get; set; }        
    }
}