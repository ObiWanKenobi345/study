using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using lab3.Entities;

namespace lab3.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=StudentContext") { }

        public DbSet<StudentEntity> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}