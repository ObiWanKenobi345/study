using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public delegate void del(ref string st);
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "S.....TR,,,i,n       g....,....1";
            Director dir = new Director();

            Student s1 = new Student();
            Student s2 = new Student();
            Tokar s3 = new Tokar();

            dir.MUp += s1.OnUp;
            dir.Plus();
            dir.Plus();
            

            dir.MUp += s3.OnUp;
            dir.MDown += s2.OnDown;

            dir.Minus();
            dir.Plus();
            Console.WriteLine("\n");
            del d1;
            


            d1 = delegate (ref string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',' || str[i] == '.' || str[i] == ' ')
                    {
                        str = str.Remove(i, 1);

                        i--;
                    }


                }
                Console.WriteLine(str1);
            };

            d1 += delegate (ref string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str = str.ToUpper();
                }


                Console.WriteLine(str1);
            };

            d1 += delegate (ref string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str = str.ToLower();
                }


                Console.WriteLine(str1);
            };

            d1 += (ref string str) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    str = str.Replace(str[i], 'S');
                }

                Console.WriteLine(str1);
            };

            
            d1(ref str1);
        }


    }

    public class Director
    {

        public delegate void Action();
        public event Action MUp;
        public event Action MDown;

        public void Plus()
        {
            MUp();
        }

        public void Minus()
        {
            MDown();
        }


    }

    public class Student
    {
        public int m = 500;


        public void OnUp()

        {
            Console.WriteLine($"Student + (money {m})");
            m = m + 100;
            Console.WriteLine("Current money: " + m);
        }

        public void OnDown()
        {
            Console.WriteLine($"Student - (money {m})");
            m = m - 100;
            Console.WriteLine("Current money: " + m);

        }
    }

    public class Tokar
    {
        public int m = 1500;
        public void OnUp()
        {

            Console.WriteLine($"Tokapb + (money {m})");
            m = m + 100;
            Console.WriteLine("Current money: " + m);
        }

        public void OnDown()
        {
            Console.WriteLine($"Tokapb - (money {m})");
            m = m - 100;
            Console.WriteLine("Current money: " + m);

        }
    }

}