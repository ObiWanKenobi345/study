using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
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
        string a="a";
        string b = "b";
        public virtual string SomeInfo()
        {
            string s = "hello" + a + b;
                
            return s;
        }
    }
}
