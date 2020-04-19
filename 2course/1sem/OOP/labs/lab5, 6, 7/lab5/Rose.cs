using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab5
{
    public class Rose : Flower
    {
        public Rose(int pric, string col)
        {
            Price = pric;

            if (Price == 0)
            {
                throw new RoseException("Нулевая стоимость");
            }

            if (Price < 1)
            {
                    Debug.Assert(Price >= 1 , "Price cannot be <1");
                throw new RoseException("<1");

            }

            Color = col;
            if (String.IsNullOrEmpty(Color))
            {
                throw new RoseException("Пустая строка");
            }

        }



        public override void Pour()
        {
            Console.WriteLine("Вы полили розу");
        }
        public override void Cut()
        {
            Console.WriteLine("Вы срезали розу");
        }
        public override void Sell()
        {
            Console.WriteLine("Вы продали розу");
        }
        public override string ToString()
        {
            return ("Информация о розе:\n Тип: " + type + " \n Где находится: " + location + " \n Цвет: " + color + " \n Цена: " + price + " ");
        }

    }
}
