using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab5
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            Console.WriteLine("IAmPrinting, plants, print:");
            Console.WriteLine("[------------------------------");
            Printer print = new Printer();
            Plant p1 = new Rose(25, "red") as Rose;
            
            print.IAmPrinting(p1);
            Console.WriteLine("\n");

            Plant p2 = new Gladiolus(100, "green");
            print.IAmPrinting(p2);
            Console.WriteLine("\n");

            Plant p3 = new Cactus(1231, "black");
            print.IAmPrinting(p3);
            Console.WriteLine("------------------------------]\n");

            Console.WriteLine("array:");
            Console.WriteLine("[------------------------------");
            Plant[] arr = new Plant[3];
            arr[0] = p1;
            arr[1] = p2;
            arr[2] = p3;

            foreach (Plant item in arr)
            {
                Console.WriteLine("\n");
                print.IAmPrinting(item);
            }
            Console.WriteLine("------------------------------]");
            
            Container b = new Container();
            b.byk = new List<Plant>();
            b.Add(p3);
            b.Add(p2);
            b.Add(p1);
            Console.WriteLine("\n");
            Console.WriteLine("Info + Price:");
            Console.WriteLine("[------------------------------");
            b.Info();
            Console.WriteLine("\n");
            b.PriceOfFlowers();
            Console.WriteLine("------------------------------]\n");
            Console.WriteLine("Поиск по цвету:");
            Console.WriteLine("[------------------------------");
            Controller cont = new Controller();
            cont.Search(b.byk);
            Console.WriteLine("------------------------------]\n");
            Console.WriteLine("\nSort + Info");
            Console.WriteLine("[------------------------------");
            cont.PriceSorting(b.byk);
            b.Info();
            Console.WriteLine("------------------------------]\n");

            Rose rose = new Rose(50, "yellow");
            rose.Cut();
            Gladiolus glad = new Gladiolus(700, "pink");
            glad.Pour();
            Cactus cact = new Cactus(800, "green");
            cact.Sell();

            Perechisl pr = Perechisl.one;
            Console.WriteLine(pr);
            Console.WriteLine((int)pr);
            */

            try
            {

                Plant p1 = new Rose(-123, "dsgddgfg");
            }
            catch (RoseException ex)
            {
                Console.WriteLine("Error1: " + ex.Message);
                Console.WriteLine("Error1: " + ex.StackTrace);
                Console.WriteLine("Error1: " + ex.TargetSite + "\n\n");
            }

            
            try
            {
                Plant p2 = new Rose(123, "");
                
            }
             catch (RoseException ex)
            {
                Console.WriteLine("Error2: " + ex.Message);
                Console.WriteLine("Error2: " + ex.StackTrace);
                Console.WriteLine("Error2: " + ex.TargetSite + "\n\n");
            }

            int x = 1;
            int y = 0;
            int z;

            try
            {
                z = x / y;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Нельзя делить на 0");
                Console.WriteLine("Error3: " + ex.Message);
                Console.WriteLine("Error3: " + ex.StackTrace);
                Console.WriteLine("Error3: " + ex.TargetSite + "\n\n");
            }

            int[] arr = new int[4] { 1, 4, 5, 7 };
            try
            {                
                arr[6] = 1;
            }
            catch (IndexOutOfRangeException ex) when (arr.Length < 5)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.StackTrace);
                Console.WriteLine("Error: " + ex.TargetSite + "\n\n");
            }

            
            try
            {
                
                List<int> f = new List<int>();
                f.Add(12);
                f[2] = 2;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Error: " + ex.StackTrace);
                Console.WriteLine("Error: " + ex.TargetSite + "\n\n");
            }


                        
            finally
            {
                Console.WriteLine("Конец");
            }


        }


    }

    public partial class Paper
    {
        public override bool Equals(object obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 123;
        }

        public Paper()
        {
            Console.WriteLine("Бумага");
        }
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


    public class Container
    {
        public List<Plant> byk;
        protected int priceOfFlowers { get; set; }

        public List<Plant> Add(Plant p)
        {
            byk.Add(p);
            return byk;
        }

        public void Info()
        {
            foreach (Plant pp in byk)
            {
                Console.WriteLine(pp.ToString());

            }
        }

        public void PriceOfFlowers()
        {
            foreach (Plant pp in byk)
            {
                priceOfFlowers += pp.Price;
            }
            Console.WriteLine("Общая стоимость цветов: " + priceOfFlowers + "$");
        }



    }

    public class Controller : Container
    {


        public void Search(List<Plant> byk)
        {
            string color;
            Console.WriteLine("Input the color");
            color = Console.ReadLine();

            foreach (Plant pp in byk)
            {
                if (pp.Color == color)
                {
                    Console.WriteLine("Найдено совпадение");
                    Printer printer = new Printer();
                    printer.IAmPrinting(pp);
                }
            }

            return;
        }

        public List<Plant> PriceSorting(List<Plant> byk)
        {


            for (int i = 0; i < byk.Count - 1; i++)
            {
                for (int j = i + 1; j < byk.Count; j++)
                {
                    if (byk[i].Price > byk[j].Price)
                    {
                        var temp = byk[i].Price;
                        byk[i].Price = byk[j].Price;
                        byk[j].Price = temp;

                    }
                }
            }



            return byk;
        }


    }

    enum Perechisl
    {
        one, two, three
    }
    struct structura
    {
        int iop;
        string jkl;
    }
}