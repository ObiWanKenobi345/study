using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class MyClass
    {
        public static int k;
        public static int field = 4;
        public static int count; //кол-во созданных объектов
        public int m;
        public string name;
        public int age;
        private int course;
        public readonly int ID; //поле только для чтения
        const double e = Math.E; //константа

        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                if (value < 1)
                    course = 1;
                else if (value > 4)
                    course = 4;
                else
                    course = value;
            }
        }

        public MyClass() //конструктор без параметров
        {
            name = "Dmitry";
            course = 2;
            age = 18;

            m = 0;
            ID = (14 * 28 / 2) + m;
            count++;
            
        }

        public MyClass(string name, int course, int age) //конструктор с параметрами
        {
            this.name = name;
            this.course = course;
            this.age = age;

            count++;
            
        }

        private MyClass(string h) { } //закрытый конструктор

        static MyClass() //статический конструктор
        {
            k = 10;
        }

        public void Print()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Age: " + age);
        }

        public static void Printst()
        {
            Console.WriteLine(k);
        }

        public override bool Equals(object obj) //переопределение метода Equals
        {
            if (this.GetType() == obj.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() //переопределение метода GetHashCode
        {
            int hashcode = count.GetHashCode();
            hashcode = 31 * hashcode + field.GetHashCode();

            return hashcode;
        }

        public override string ToString()
        {
            return "Person: " + name + " " + course + " " + age;
        }


    }


    class Data
    {
        public int day;
        public int month;
        public int year;
        public static int cnt;

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value < 1)
                    day = 1;
                else if (value > 31)
                    day = 4;
                else
                    day = value;
            }
        }
        public int Month
        {
            get
            {
                return day;
            }
            set
            {
                if (value < 1)
                    month = 1;
                else if (value > 12)
                    month = 12;
                else
                    month = value;
            }
        }

        public Data(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            cnt++;
        }

        public void Printdata1()
        {
            Console.WriteLine(day + "/" + month +"/" + year);
        }

        public void Printdata2()
        {
            string mes=" ";
            if (month == 1) mes = " января ";
            if (month == 2) mes = " февраля ";
            if (month == 3) mes = " марта ";
            if (month == 4) mes = " апреля ";
            if (month == 5) mes = " мая ";
            if (month == 6) mes = " июня ";
            if (month == 7) mes = " июля ";
            if (month == 8) mes = " августа ";
            if (month == 9) mes = " сентября ";
            if (month == 10) mes = " октября ";
            if (month == 11) mes = " ноября ";
            if (month == 12) mes = " декабря ";
            Console.WriteLine(day + mes + year + " года");
        }

    }


        class MainClass
        {
            static void ro(ref int l, out int n)
            {
                n = 50;
                Console.WriteLine("l1: " + l); //50
                l = 200;
                Console.WriteLine("l2: " + l); //200
            }
        public static void Main(string[] args)
        {
            int x = 50;
            Console.WriteLine("Ref, out:\n " + "x1: " + x); //50
            ro(ref x, out int n);
            Console.WriteLine("x2: " + x); //200
            Console.WriteLine("n: " + n + "\n");


            MyClass stud1 = new MyClass();
            stud1.Print();
            Console.WriteLine();
            MyClass stud2 = new MyClass("Viktor", 1, 17);
            stud2.Print();
            Console.WriteLine();
            MyClass stud3 = new MyClass("Petr", 3, 20);
            stud3.Print();
            Console.WriteLine();
            Console.WriteLine("Кол-во записей:" + MyClass.count);
            Console.WriteLine();

            Class1 j = new Class1(); //partial
            Console.WriteLine("partial: ");
            j.pr();
            Console.WriteLine();

            int pr1 = 10;
            int pr2 = 15;


            Console.WriteLine("Сравнение переменных pr1 и pr2: " + pr1.Equals(pr2));
            Console.WriteLine(pr1.GetHashCode());
            Console.WriteLine(pr2.GetHashCode());
            Console.WriteLine();
            Console.WriteLine("Информация об объекте: " + stud1 + "\n");

            Console.WriteLine("Метод Print: ");
            stud1.Print();
            Console.WriteLine();
            stud2.Course = 5;
            Console.WriteLine("Проверка set: " + stud2.Course);
            Console.WriteLine("Тип созданного объекта: " + stud1.GetType().Name);

            MyClass[] ObjArr = new MyClass[5];
            for (int i = 0; i < 5; i++)

                ObjArr[0] = stud1;
            ObjArr[1] = stud2;
            ObjArr[2] = stud3;

            // for (int i = 0; i < 3; i++)
            // {
            //     ObjArr[i].Print();
            // }
            Console.WriteLine();
            Data d1 = new Data(4, 10, 2017);
            Data d2 = new Data(8, 5, 2017);
            Data d3 = new Data(5, 7, 2018);
            Data d4 = new Data(1, 3, 2018);
            Data d5 = new Data(6, 4, 2016);
            Data d6 = new Data(2, 9, 2016);
            //d1.Printdata1();
            //d1.Printdata2();
            Console.WriteLine();

            Data[] Arr = new Data[6];
            Arr[0] = d1;
            Arr[1] = d2;
            Arr[2] = d3;
            Arr[3] = d4;
            Arr[4] = d5;
            Arr[5] = d6;

            for (int i = 0; i < 6; i++)
            {
                //  Arr[i].Printdata1();
                Arr[i].Printdata2();
            }
            int f;
            int y;
            Console.WriteLine("Введите год:");
            f = int.Parse(Console.ReadLine());
            Console.WriteLine("Совпадения: ");
            for (int i = 0; i < 6; i++) {
                if (Arr[i].year == f) Arr[i].Printdata1();              
            }
            Console.WriteLine("Введите число: ");
            y = int.Parse(Console.ReadLine());
            for (int i = 0; i < 6; i++)
            {
                if (Arr[i].day == y || Arr[i].month== y || Arr[i].year.ToString().Contains(y.ToString())) Arr[i].Printdata1(); 
            }

            var an = new { Name = "Dmitriy", Age = 18 };
            Console.WriteLine("\nИмя: " + an.Name);
            Console.WriteLine("Возраст: " + an.Age);

        }
    }
}
