using System.Data.Entity;

namespace MVC_APP.Models
{
    public class PhoneContext : DbContext
    {
        public DbSet<Phone> Phones { set; get; }
    }
}