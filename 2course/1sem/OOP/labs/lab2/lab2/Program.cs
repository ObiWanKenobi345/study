using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{    class Program
    {        static void Main(string[] args)
        {
            // 1.a
            sbyte a = 100;
            short b = 120;
            int c = 50;
            long d = 80;
            byte e = 250;
            char f = 'f';
            bool g = true;
            ushort u = 10;
            uint m = 70;
            ulong s = 1000;
            decimal l = 565478;
            string v = "hello";
            object ob;

            var person = (name: "Tom", 25, 81.23);
            Console.WriteLine(person.Item1);

            // 1.b
            c = b;
            d = e;
            f = (char)c;
            d = (char)s;



            // 1.c
            int abc = 50;
            object k = abc;
            int dfe = (int)abc;



            // 1.d
            Console.WriteLine("1.d:\n");
            var myString = "String";
            var myChar = 'c';
            Console.WriteLine($"{myString}     {myString.GetType()}");
            Console.WriteLine($"{myChar}     {myChar.GetType()}");
            Console.WriteLine("\n\n\n");



            //1.e
            Console.WriteLine("1.e:\n");
            Nullable<int> n1 = 5;
            int? n2 = null;
            Console.WriteLine("n1.HasValue: " + n1.HasValue);
            Console.WriteLine("n2.HasValue: " + n2.HasValue);
            Console.WriteLine("\n\n\n");



            //2.a
            Console.WriteLine("2.a:\n");
            string s1 = "string1";
            string s2 = "string2";
            if (s1==s2)
            {
                Console.WriteLine("strings are same");
            }
            else
            {
                Console.WriteLine("strings aren't same");
            }
            Console.WriteLine("\n\n\n");



            //2.b
            string s3 = "string3";
            Console.WriteLine("2.b:\n");
            Console.WriteLine("concat: " + String.Concat(s1, s2, s3));

            string s_1 = String.Copy(s1);
            Console.WriteLine("copy: " + s_1);

            Console.WriteLine("s1.Substring string1: " + s1.Substring(0, 4));

            string names = "One.Two.Three";
            Console.WriteLine("Split: ");
            string[] nameArray = names.Split('.');
            foreach (string name in nameArray)
                Console.WriteLine(name);

            string st = "one_two_three";
            string j = "+";
            st = st.Insert(3, j);
            Console.WriteLine("Insert:\n" + st);
            Console.WriteLine("Remove:\n" + s2.Remove(1, 4));
            Console.WriteLine("\n\n\n");


            //2.c
            Console.WriteLine("2.c:\n");
            string n = null;
            Console.WriteLine(n);



            //2.d
            Console.WriteLine("2.d:\n");
            StringBuilder sb = new StringBuilder("QWERTY", 70);
            sb.Remove(0, 1);
            sb.Remove(2, 1);
            sb.Insert(0, 'Z');
            sb.Append('L');
            Console.WriteLine(sb.ToString());
            Console.WriteLine("\n\n\n");


            //3.a
            Console.WriteLine("3.a:\n");

            int[,] array = new int[7, 7];
            for (int i1 = 0; i1 < 7; i1++)
            {
                for (int i2 = 0; i2 < 7; i2++)
                {
                    array[i1, i2] = i1;
                    Console.Write("   " + array[i1, i2]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n");



            //3.b
            Console.WriteLine("3.b:\n");

            string[] str3b = { "One", "Two", "Three", "Four", "Five" };
            Console.WriteLine("Длина массива: " + str3b.Length);
            Console.WriteLine("Массив:");
            for (int h = 0; h < str3b.Length; h++)
            {
                Console.WriteLine("[" + h + "]=" + str3b[h]);
            }
            Console.WriteLine("Какой элемент заменить?");
            string change = Console.ReadLine();
            Console.WriteLine("Новое значение:");
            string changes = Console.ReadLine();
            str3b[Convert.ToInt32(change)] = changes;
            Console.WriteLine();
            for (int h = 0; h < str3b.Length; h++)
            {
                Console.WriteLine("[" + h + "]=" + str3b[h]);
            }
            Console.WriteLine("\n\n\n");



            //3.c
            Console.WriteLine("3.c:\n");
            Console.WriteLine("Введите 9 цифр:");
            double[] fmass = new double[9];
            for (int li = 0; li < fmass.Length; li++)
            {
                fmass[li] = Convert.ToDouble(Console.ReadLine());
            }
            int _li = 2, li2 = 0;
            Console.WriteLine();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < _li; y++)
                {
                    Console.Write(fmass[li2]);
                    li2++;
                }
                Console.WriteLine();
                _li++;
            }


            Console.WriteLine("\n\n\n");



            //3.d
            Console.WriteLine("3.c:\n");
            Console.WriteLine();
            var list = new List<string>();
            list.Add("one");
            list.Add("two");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n\n");



            //4.a,b,c
            Console.WriteLine("4.a.b.c:\n");
            var cor = (number: 8, hello:"Dima", symbol: 'q', world:"World", count:50);
            Console.WriteLine("Кортеж целиком:" + cor);
            Console.WriteLine("1,3,4 элементы:" + cor.Item1 + "   " + cor.Item3 + "   " + cor.Item4);
            Console.WriteLine("\n\n\n");



            //4.d,e
            Console.WriteLine("4.d.e:\n");
            (int, string, char) CreateCortage(string name)
            {
                int len = name.Length;
                string sm = "word: " + name;
                char ch = (char)name[0];
                return (len, sm, ch);
            }
            var (one, two, three) = CreateCortage(cor.Item2);
            Console.WriteLine($"Количество символов = {one}");
            Console.WriteLine(two);
            Console.WriteLine($"Первый символ = {three}");
            if (cor.Item1 == cor.Item5)
            {
                Console.WriteLine("1 и 5 элементы равны");
            }
            else
            {
                Console.WriteLine("1 и 5 элементы не равны");
            }
            Console.WriteLine("\n\n\n");



            //5
            int[] ar = { 10, 11, 111, 20, 22, 30, 1000 };
            string q = "Stroka";

            var (max, min, summ, first) = GetCortage(ar, q);
            Console.WriteLine($"минимальный элемент:{min}");
            Console.WriteLine($"максимальный элемент:{max}");
            Console.WriteLine($"сумма всех элементов:{summ}");
            Console.WriteLine($"Первая буква строки:{first}");

            Console.ReadKey();
        }
        static (int, int, int, char) GetCortage(int[] mass, string strk)
        {
            int min = mass[0];
            int max = mass[0];
            int summ = 0;
            char bukva = strk[0];
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i] < min)
                {
                    min = mass[i];
                }
                else if (mass[i] > max)
                {
                    max = mass[i];
                }
                summ = summ + mass[i];
            }

            return (max, min, summ, bukva);
        }

        
    }
}
