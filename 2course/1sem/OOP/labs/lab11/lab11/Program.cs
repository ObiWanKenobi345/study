using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {


        static void Main(string[] args)
        {
            string[] month = { "January", "Februaby", "March", "April", "May", "June", "July", "August", "Septemer", "October", "November", "December"};


            // 1
            Console.Write("Введите длину строки: ");
            int x = Convert.ToInt32(Console.ReadLine());

            var query_1 = from m in month
                         where m.Length == x
                         select m;
                        
            foreach (var item in query_1)
            {
                Console.WriteLine("Запрос 1: {0}", item);
            }
            Console.WriteLine("\n");

            //summer
            IEnumerable<string> month1 = month.Skip(5);
            IEnumerable<string> month2 = month1.Take(3);
            Console.WriteLine("Летние месяцы:");
            foreach (string s in month2)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n");

            //winter
            IEnumerable<string> month3 = month.Take(2).Concat(month.Skip(11));
            Console.WriteLine("Зимние месяцы:");
            foreach (string s in month3)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n");
            var query_3 = from m in month
                         orderby m
                         select m;

            Console.WriteLine("В алфавитном порядке: ");
            foreach (var item in query_3)
            {
                Console.WriteLine("Запрос 3: {0}", item);
            }
            Console.WriteLine("\n");

            var query_4 = from m in month
                         where m.Contains("u") == true
                         where m.Length > 4
                         select m;

            Console.WriteLine("Содержит u: ");
            foreach (var item in query_4)
            {
                Console.WriteLine("Запрос 4: {0}", item);
            }

            List<Date> list = new List<Date>();

            list.Add(new Date(12, 4, 1991));
            list.Add(new Date(20, 6, 2005));
            list.Add(new Date(13, 9, 1945));
            list.Add(new Date(1, 1, 2000));
            list.Add(new Date(13, 9, 2017));
            list.Add(new Date(9, 2, 1945));

            var listQuery1 = from m in list
                             where m.year == 1945
                             select m;
            foreach (var item in listQuery1)
            {
                Console.WriteLine("Task1: ");
                item.InfoOfDate();
            }

            var listQuery2 = from m in list
                             where m.month == 9
                             select m;
            foreach (var item in listQuery2)
            {
                Console.WriteLine("Task2:");
                item.InfoOfDate();
            }
            var listQuery3 = from m in list
                             where m.year > 1900
                             where m.year < 1999
                             select m;
            foreach (var item in listQuery3)
            {
                Console.WriteLine("Task3:");
                item.InfoOfDate();
            }

            var listQuery4 = from m in list
                             orderby m.year descending, m.month, m.day
                             select m;

            var buf = listQuery4.First();
            Console.WriteLine("Максимальная дата: ");
            buf.InfoOfDate();


            var listQuery5 = list.First(p => p.day == 13);
            Console.WriteLine("Первый элемент с 13 днем: ");
            listQuery5.InfoOfDate();
            var listQuery6 = from m in list
                             orderby m.year, m.month, m.day
                             select m;
            foreach (var item in listQuery6)
            {
                Console.WriteLine("Task6: ");
                item.InfoOfDate();
            }
        }
    }

    class Date
    {
        enum Month { Января = 1, Ферваля, Марта, Апреля, Мая, Июня, Июля, Августа, Сентября, Октября, Ноября, Декабря };

        static int CountOfObjects = 0;
        private int DayValue;
        private int MonthValue;
        private int YearValue;


        public void InfoOfDate()
        {

            Console.WriteLine("----- {0} {1} {2}", this.day, (Month)this.month, this.year);

            Console.WriteLine();
        }

        public int day
        {
            get
            {
                return DayValue;
            }
            set
            {

                DayValue = value;

            }
        }
       
        public int month
        {
            get
            {
                return MonthValue;
            }
            set
            {
                MonthValue = value;
            }
        }
        
        public int year
        {
            get
            {
                return YearValue;
            }
            set
            {
                YearValue = value;
            }
        }

        public Date(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
            if (d < 1 || d > 31 || m < 1 || m > 12 || y < 1 || y > 9999)
            {
                Console.WriteLine("Некорректно введены данные");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Date stud = (Date)obj;
            return (this.day == stud.day && this.month == stud.month && this.year == stud.year);
        }

        public override int GetHashCode()
        {
            int hash = 269;
            hash = (day < 0) ? 0 : day.GetHashCode();
            hash = (hash * 47) + year.GetHashCode();
            return hash;
        }
    }
}