using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Entities
{
    public class StudentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}