using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            Console.WriteLine("Студент:");
            student.study();
            Console.WriteLine();
            Prepod prepod = new Prepod();
            Console.WriteLine("Преподаватель:");
            prepod.study();
            ((IStudy)prepod).study();
        }
    }
}
