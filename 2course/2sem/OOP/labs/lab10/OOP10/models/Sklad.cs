using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP10
{
    public class Sklad
    {
        public string View;
        public string Name;
        public string Price;
        public int Count;

        public Sklad(string view, string name,string price, int count)
        {
            this.View = view;
            this.Name = name;
            this.Price = price;
            this.Count = count;
        }

       
    }
}
