using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП13
{
    class Decorator
    {
    }
    abstract class Autobus
    {
        public Autobus(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianAutobus : Autobus
    {
        public ItalianAutobus() : base("Автобус в Италию")
        { }
        public override int GetCost()
        {
            return 100;
        }
    }
    class BulgerianAutobus : Autobus
    {
        public BulgerianAutobus()
            : base("Автобус в Болгарию")
        { }
        public override int GetCost()
        {
            return 80;
        }
    }

    abstract class AutobusDecorator : Autobus
    {
        protected Autobus Autobus;
        public AutobusDecorator(string n, Autobus Autobus) : base(n)
        {
            this.Autobus = Autobus;
        }
    }

    class RedAutobus : AutobusDecorator
    {
        public RedAutobus(Autobus p)
            : base(p.Name + ", красного цвета", p)
        { }

        public override int GetCost()
        {
            return Autobus.GetCost() + 10;
        }
    }

    class OpenRoofAutobus : AutobusDecorator
    {
        public OpenRoofAutobus(Autobus p)
            : base(p.Name + ", с открытой крышей", p)
        { }

        public override int GetCost()
        {
            return Autobus.GetCost() + 20;
        }
    }
}
