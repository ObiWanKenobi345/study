using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Set
    {

        public int[] Elements = new int[5];

        public int this[int index]
        {
            get
            {

                return Elements[index];
            }
            set
            {
                for (int i = 0; i < Elements.Length; i++)
                {
                    if (Elements[i] == value)
                    {
                        return;
                    }
                }
                Elements[index] = value;
            }

        }
       
        public Set(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Elements[i] = arr[i];
            }
        }

        public void Output(params int[] arr)
        {
            int n = Elements.Length;
            Console.Write('[');
            for (int i = 0; i < n; i++)
            {
                if (Elements[i] == 0)
                {
                    Array.Copy(Elements, i + 1, Elements, i, n - i - 1);
                    n--;
                    
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(Elements[i].ToString() + ' ');
            }
            Console.Write(']');
        }


        public static Set operator -(Set s, int n)
        {
            for (int i = 0; i < s.Elements.Length; i++)
            {
                if (s[i] == n)
                {
                    for (int j = i; j < s.Elements.Length - 1; j++)
                    {
                        s.Elements[j] = s.Elements[j + 1];
                    }
                    break;
                }
            }
            return s;
        }

        public static Set operator *(Set s1, Set s2)
        {
            Set s3 = new Set();
            int index = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        s3[index] = s1[i];
                        index++;
                    }
                }

            }
            return s3;
        }

        public static bool operator > (Set s1, Set s2)
        {
            bool compare = false;
            for (int i = 1; i < 5; i++)
            {
                for (int j  = 1; j < 5; j++)
                {
                    if (s1[i] == s2[j] && s1[i-1] == s2[j-1] )
                    {
                        compare = true;
                        return compare;
                    }
                }
            }
            return compare;
        }

        public static bool operator < (Set s1, Set s2)
        {
            bool compare = true;
            for (int i = 0; i < 5; i++)
            {
                if (s1[i] != s2[i])
                {
                    compare = false;
                }
            }
            return compare;
        }


        public static Set operator &(Set s1, Set s2)
        {
            Set s3 = new Set();
            for (int i = 0; i < s1.Elements.Length; i++)
            {
                s3.Elements[i] = s1.Elements[i] + s2.Elements[i];
            }
            return s3;
        }

    }

    public class Owner
    {
        private int id;
        private string name;
        private string name_organization;

        public Owner()
        {
            this.id = 444;
            this.name = "Dmitriy";
            this.name_organization = "Organization";
        }

        public void Print()
        {
            Console.WriteLine($"id: {id}");
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"organization: {name_organization}");
        }

        public static explicit operator string(Owner obj)
        {
            return "Информация о пользователе: " + obj.id + " " + obj.name + " (" + obj.name_organization + ")";
        }
    }

    public class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            this.day = 27;
            this.month = 10;
            this.year = 2017;
        }

        public void Print()
        {
            Console.WriteLine($"Date:{day}.{month}.{year}");
        }
    }
    public static class Dot
    {
        public static String Dots(this String st)
        {
            st = st + '.';
            return st;
        }
    }

   

    static class MathObject
    {
        public static int Min(params int[] arr)
        {
            Array.Sort(arr);
            return arr[0];
        }

        public static int Max(params int[] arr)
        {
            Array.Sort(arr);
            return arr[arr.Length - 1];
        }

        public static int Count(params int[] arr)
        {
            return arr.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool compare;
            Set s1 = new Set(35, 21, 43, 72, 81);
            Console.WriteLine("s1:");
            s1.Output();
            Console.WriteLine("\ns1 + del:");
            s1 = s1 - 81; //удаление
            Console.Write('[');
            for (int i = 0; i < s1.Elements.Length-1; i++)
            {
                Console.Write(s1.Elements[i].ToString() + ' ');
            }
            Console.Write(']');
            
            Set s2 = new Set(21, 43, 72, 81, 28);
            Console.WriteLine("\ns2:");
            s2.Output();
            Set s3;
            Console.WriteLine("\ns1*s2:");
            s3 = s1 * s2; //пересечение
            s3.Output();
            Console.WriteLine();
            Set s4 = new Set(10, 44, 7, 8, 9);
            Set s5 = new Set(1, 2, 7, 8, 9);
            compare = s4 < s5; //сравнение
            Console.WriteLine("s4 < s5?:  " + compare);
            compare = s4 > s5; //проверка на подмножество
            Console.WriteLine("Проверка на подмножество:  " + compare);

            String st = "Точка в конце предложения";
            Console.WriteLine(st.Dots());
            Set x = new Set(10, 44, 78, 85, 593);
            x.Output();
            Console.WriteLine("\nМin: " + MathObject.Min(x.Elements));
            Console.WriteLine("Маx: " + MathObject.Max(x.Elements));
            Console.WriteLine("Кол-во элементов: " + MathObject.Count(x.Elements));
            Owner own = new Owner();
            own.Print();
            Date date = new Date();
            date.Print();
            s3 = s4 & s5;
            Console.WriteLine("s4:");
            s4.Output();
            Console.WriteLine("\ns5:");
            s5.Output();
            Console.WriteLine("\ns4&s5:");
            Console.Write('[');
            for (int i = 0; i < s3.Elements.Length; i++)
            {
                Console.Write(s3.Elements[i].ToString() + ' ');
            }
            Console.WriteLine(']');
            Set s6 = new Set(5, 7, 5, 0, 10);
            s6.Output();
            Console.WriteLine();
            Owner m = new Owner();
            string b = (string)m;
            Console.WriteLine(b);

        }

    }
}