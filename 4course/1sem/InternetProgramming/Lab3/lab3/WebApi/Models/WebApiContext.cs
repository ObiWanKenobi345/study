using System.Data.Entity;

namespace WebApi.Models
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base() { }

        public DbSet<WebApi.Models.Student> Students { get; set; }
    }
}