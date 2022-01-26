using Microsoft.AspNetCore.Mvc.Localization;

namespace Personal.Models
{
    public class HeaderModel
    {
        public LocalizedHtmlString Title { get; set; }
        public string Active
        {
            set
            {
                switch (value)
                {
                    case "CV":
                        {
                            ActiveCV = "active";
                            break;
                        }
                    case "Work":
                        {
                            ActiveWork = "active";
                            break;
                        }
                    case "Blog":
                        {
                            ActiveBlog = "active";
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        public string ActiveCV { get; set; } = string.Empty;
        public string ActiveWork { get; set; } = string.Empty;
        public string ActiveBlog { get; set; } = string.Empty;
    }
}