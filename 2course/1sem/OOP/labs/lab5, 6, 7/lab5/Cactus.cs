using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Cactus : Flower
    {
        public Cactus(int pric, string col)
        {
            color = col;
            price = pric;
        }
        public override void Pour()
        {
            Console.WriteLine("Вы полили кактус");
        }
        public override void Cut()
        {
            Console.WriteLine("Вы срезали кактус");
        }
        public override void Sell()
        {
            Console.WriteLine("Вы продали кактус");
        }

        public override string ToString()
        {
            return ("Информация о кактусе:\n Тип: " + type + " \n Где находится: " + location + " \n Цвет: " + color + " \n Цена: " + price + " ");
        }

    }
}
