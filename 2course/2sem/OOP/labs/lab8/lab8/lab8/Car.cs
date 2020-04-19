using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public string Year { get; set; }

        public ICollection<User> Users { get; set; }
        public Car()
        {
            Users = new List<User>();
        }
    }
}
