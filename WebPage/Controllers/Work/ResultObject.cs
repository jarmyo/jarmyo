﻿namespace Personal.Controllers
{
    public class ResultObject : IDisposable
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
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            // clean all?
        }
    }
}