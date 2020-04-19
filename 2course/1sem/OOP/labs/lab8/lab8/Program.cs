using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{

     interface IInterf<T>
    {
        void Add(T input);
        void Remove(T el);
        void Show();
    }

    class MyClass : IInterf<string>
    {
        List<string> list = new List<string>();
        public void Add(string el)
        {
            list.Add(el);
        }

        public void Remove(string el)
        {
            list.Remove(el);
        }

        public void Show()
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }

    }
    class CollectionType<T> : IInterf<T> 
    {
        List<T> list2 = new List<T>();
        T value;
        public CollectionType(T el)
        {
            list2.Add(el);
        }
        public CollectionType()
        {
            value = default(T);
        }

        public void Add(T el)
        {
            list2.Add(el);
        }

        public void Remove(T el)
        {
            list2.Remove(el);
        }

        public void Show()
        {
            foreach (var element in list2)
            {
                Console.WriteLine(element);
            }
        }


    }
    class CollectionType2<T> where T: Flower
    {
        List<T> list2 = new List<T>();
        T value;
        public CollectionType2(T el)
        {
            list2.Add(el);
        }
        public CollectionType2()
        {
            value = default(T);
        }

        public void Add(T el)
        {
            list2.Add(el);
        }

        public void Remove(T el)
        {
            list2.Remove(el);
        }

        public void Show()
        {
            foreach (var element in list2)
            {
                Console.WriteLine(element);
            }
        }
    }
    

    interface IPlant
    {
        void Pour();
        void Cut();
        void Sell();
        String ToString();
    }

    class PlantException : Exception
    {
        public PlantException(string message) : base(message)
        { }
    }

    class RoseException : PlantException
    {
        public RoseException(string message) : base(message)
        { }
    }

    class GladException : PlantException
    {
        public GladException(string message) : base(message)
        { }
    }


    public abstract class Plant
    {
        protected string type;
        protected string location;
        protected int price;
        protected string color;
        public int Price
        {
            get => price;
            set => price = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
    }

    public abstract class Flower : Plant, IPlant
    {

        public abstract void Pour();
        public abstract void Cut();
        public abstract void Sell();
        public Flower()
        {
            type = "Цветок";
            location = "Магазин";
        }
    }

    public class Rose : Flower
    {
        public Rose(int pric, string col)
        {

            Price = pric;

            if (Price == 0)
            {
                throw new RoseException("Нулевая стоимость");
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
            return ("Информация о розе\n type -" + type + " \n location - " + location + " \n color - " + color + " \n price - " + price + "\n");
        }

    }

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
            return ("Информация о гладиолусе\n type -" + type + " \n location - " + location + " \n color - " + color + " \n price - " + price + " ");
        }

    }



    class Program
    {
        static void Main(string[] args)
        {


            MyClass Str = new MyClass();
            Str.Add("one");
            Str.Add("two");
            Str.Add("three");
            Str.Show();
            Console.WriteLine("\n");
            Str.Remove("one");
            Str.Show();
            Console.WriteLine("\n");

            CollectionType<int> Col = new CollectionType<int>();
            CollectionType<string> Str2 = new CollectionType<string>("one");

            Col.Add(123);
            Col.Add(234);
            Col.Add(345);
            Col.Add(456);
            Col.Remove(345);
            Col.Show();
            Console.WriteLine("\n");

            Str2.Add("two");
            Str2.Add("three");
            Str2.Show();
            Console.WriteLine("\n");

            CollectionType<Plant> Col2 = new CollectionType<Plant>();
            Col2.Add(new Rose(1244, "red"));
            Col2.Show();
            Console.WriteLine("\n");

            Col2.Add(new Gladiolus(312, "green"));
            Col2.Show();
        }
    }


    

}
 