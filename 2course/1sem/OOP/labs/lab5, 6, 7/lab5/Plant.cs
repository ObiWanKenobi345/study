using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public abstract class Plant : Printer
    {
        protected string type;
        protected string location;
        protected int price;
        protected string color;
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public string Color
        {
            get
            {
               return  color;
            }
            set
            {
                color = value;
            }
        }
    }
}
