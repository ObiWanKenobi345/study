using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            Random r = new Random();
            ArrayList arrlist = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                arrlist.Add(r.Next(0, 10));
            }
            Console.WriteLine("ArrayList:");
            foreach (object o in arrlist)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine("\n\n");
            
            arrlist.Add("qwerty");
            arrlist.RemoveAt(0);
            Console.WriteLine("new ArrayList:");
            foreach (object o in arrlist)
            {
                Console.WriteLine(o);
            }
            
            Console.WriteLine("\n\n");

            Console.WriteLine("Введите элемент массива");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Element:" + arrlist[arrlist.IndexOf(c)]);
            #endregion

            List<float> list1 = new List<float>();
            list1.Add(4.5F);
            list1.Add(1);
            list1.Add(1.2F);
            list1.Add(3.1F);
            list1.Add(8.5F);
            Console.WriteLine("\n\nList:");
            
            foreach (object item in list1)
            {
               
                Console.WriteLine(" element of list: " + item);
            }
            Console.WriteLine("Введите кол-во удаляемых элементов");
            int key = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < list1.Count; i++)
            {
                while (key > 0)
                {
                    list1.RemoveAt(i);
                    key--;
                }
            }
            Console.WriteLine("\n\nList:");
            foreach (object item in list1)
            {
                
                Console.WriteLine(" element of list: " + item);
            }

            Console.WriteLine();

            Stack<float> s1 = new Stack<float>();

            for (int i = 0; i < list1.Count; i++)
            {
                s1.Push(list1[i]);

            }
            Console.WriteLine("\n\nStack:");
            foreach (object item in s1)
            {
                Console.WriteLine(" element of stack: " + item);
            }

            Console.WriteLine("Введите элемент ");
            float f = Convert.ToSingle(Console.ReadLine());

            for (int i = 0; i < 4; i++)
            {
                
                if (s1.Peek() == f)
                {
                    Console.WriteLine(s1.Pop() + "---> Наш элемент\n\n");
                    break;
                }
                s1.Pop();
            }


            
            List<Plant> p = new List<Plant>();
            p.Add(new Plant("green", 123));
            p.Add(new Plant("red", 333));
            p.Add(new Plant("yellow", 444));
            Console.WriteLine("new List:");
            foreach (var item in p)
            {
                Console.WriteLine("Price and Color : " + item.Price + " " + item.Color);
            }

            p.RemoveAt(0);
            Console.WriteLine("\n");
            foreach (var item in p)
            {
                Console.WriteLine("Price and Color : " + item.Price + " " + item.Color);
            }

            Stack<Plant> s2 = new Stack<Plant>();

            for (int i = 0; i < p.Count; i++)
            {
                s2.Push(p[i]);

            }
            Console.WriteLine("\nnew Stack:");
            foreach (var item in s2)
            {
                Console.WriteLine("Price and Color : " + item.Price + " " + item.Color);
            }

            Console.WriteLine("\nObservableCollection:");

            ObservableCollection<Plant> obs = new ObservableCollection<Plant>();

            obs.CollectionChanged += Plant_CollectionChanged;

            obs.Add(new Plant("orange", 23435));
            obs.RemoveAt(0);
        }


        private static void Plant_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // добавление
                    Plant newPlant = e.NewItems[0] as Plant;
                    Console.WriteLine("Добавлен новый объект: {0}  {1}", newPlant.Price, newPlant.Color);
                    break;
                case NotifyCollectionChangedAction.Remove: // удаление
                    Plant oldPlant = e.OldItems[0] as Plant;
                    Console.WriteLine("Удален объект: {0}   {1}", oldPlant.Price, oldPlant.Color);
                    break;

            }
        }

    }


    public class Plant
    {

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

        public Plant(string c, int p)
        {
            Price = p;
            Color = c;
        }
    }


}
