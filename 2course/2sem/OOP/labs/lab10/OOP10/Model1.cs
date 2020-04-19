namespace OOP10
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Default")
        {
        }

   
        public DbSet<Storage> Store { get; set; }
    }
}
