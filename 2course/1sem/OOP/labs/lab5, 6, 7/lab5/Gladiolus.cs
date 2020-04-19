using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class Gladiolus : Flower
    {
        public Gladiolus(int pric, string col)
        {
            color = col;
            price = pric;
        }
        public override void Pour()
        {
            Console.WriteLine("Вы полили гладиолус");
        }
        public override void Cut()
        {
            Console.WriteLine("Вы срезали гладиолус");
        }
        public override void Sell()
        {
            Console.WriteLine("Вы продали гладиолус");
        }

        public override string ToString()
        {
            return ("Информация о гладиолусе:\n Тип: " + type + " \n Где находится: " + location + " \n Цвет: " + color + " \n Цена: " + price + " ");
        }

    }
}
