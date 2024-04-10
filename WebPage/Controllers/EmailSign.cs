namespace Personal.Controllers
{
    public class EmailSign(IWebHostEnvironment env) : Controller
    {
        private readonly IWebHostEnvironment _host = env;

        [HttpGet]
        public FileResult Index()
        {
            return Sign;
        }
        /// <summary>
        /// This method returns an image with my sign
        /// </summary>
        /// <param name="id">code or GUID of the mail to track if is readed or not</param>
        /// <returns>sign image</returns>
        [HttpGet]
        public FileResult Track(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                //get the code to track, a GUID from gmail.
                //if first time, save a record
                //if reopen, increment the counter.
                //return the sign image
            }
            return Sign;
        }
        private FileResult Sign
        {
            get
            {
                var FileNameWithPath = Path.Combine(_host.WebRootPath, @"assets\sign.png");
                byte[] bytes = System.IO.File.ReadAllBytes(FileNameWithPath);
                return File(bytes, "application/octet-stream", "jarm.yo.sign.png");
            }
        }
    }
}