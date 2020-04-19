using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public sealed class Bush : Plant, IPlant
    {
        public Bush(string typ, string loc)
        {
            location = loc;
            type = typ;
        }
        public void Pour()
        {
            Console.WriteLine("Вы полили куст");
        }
        public void Cut()
        {
            Console.WriteLine("Вы срезали куст");
        }
        public void Sell()
        {
            Console.WriteLine("Вы продали куст");
        }

        public override string ToString()
        {
            return ("Информация о Кусте:\n Тип: " + type + " \n Где находится: " + location + " \n Цвет: " + color);
        }


    }
}
