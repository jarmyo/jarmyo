namespace Personal.Controllers
{
    public class ResultObject
    {
        public ResultObject()
        {
            GUID = Guid.NewGuid().ToString();
            Attributes = new Dictionary<string, string>();
        }
        public bool OK { get; set; }
        public string GUID { get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
    }
}