using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    class Prepod : Student, IStudy
    {
        void IStudy.study()
        {
            Console.WriteLine("Учу");
        }

    }
}
