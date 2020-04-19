using System.Web;

namespace WebApi.Models
{
    public abstract class ApiModelBase
    {
        public static string BasePath = HttpContext.Current.Server.MapPath("~");

        public class LinkItem {
            public string Rel { get; set; }
            public string Href { get; set; }
        }

        public LinkItem Link;

        public ApiModelBase() {
            Link = new LinkItem
            {
                Rel = "href",
                Href = string.Empty
            };
        }
    }
}