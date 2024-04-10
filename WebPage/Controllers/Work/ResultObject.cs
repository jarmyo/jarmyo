using System.Xml;
using System.Xml.Serialization;
namespace Personal.Controllers
{
    public class ResultObject : IDisposable
    {
        public ResultObject()
        {
            GUID = Guid.NewGuid().ToString();
            Attributes = [];
        }
        public bool OK { get; set; }
        public string GUID { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        [XmlIgnore]
        public Dictionary<string, string> Attributes { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            // clean all?
        }
        public string SerializeXml()
        {
            XmlSerializer xmlSerializer = new(typeof(ResultObject));
            XmlSerializer xsSubmit = xmlSerializer;
            string xml = string.Empty;
            XmlWriterSettings settings = new()
            {
                OmitXmlDeclaration = false
            };
            using (var sww = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(sww, settings))
            {
                xsSubmit.Serialize(writer, this);
                xml = sww.ToString();
            }
            return xml;
        }
    }
}