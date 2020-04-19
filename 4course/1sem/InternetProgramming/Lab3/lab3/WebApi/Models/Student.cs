using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public LinkItem Link {
            get {
                return new LinkItem()
                {
                    Rel = "href",
                    Href = LinkItem.BasePath + "api/students.json/" + Id
                };
            }
        }

        public Student() {
            Id = -1;
            Name = string.Empty;
            Phone = string.Empty;
        }

        public Student(int id) {
            this.Id = id;
        }

        public Student(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        
        public Student(int id, string name, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }
    }
}