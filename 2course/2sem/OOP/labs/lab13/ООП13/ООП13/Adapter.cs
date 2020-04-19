using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ООП13
{
    class Adapter
    {
    }
    interface ITransport
    {
        void Drive();
    }
    // класс передвижения по оси X
    class Auto : ITransport
    {
        public void Drive()
        {
            MessageBox.Show("Машина едет по оси х");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    // интерфейс передвижения по оси Y
    interface IAutoY
    {
        void Move();
    }
    // класс передвижения по оси Y
    class AutoY : IAutoY
    {
        public void Move()
        {
            MessageBox.Show("Машина едет по оси Y");
        }
    }
    // Адаптер от AutoY к ITransport
    class AutoYToTransportAdapter : ITransport
    {
        AutoY autoY;
        public AutoYToTransportAdapter(AutoY c)
        {
            autoY = c;
        }

        public void Drive()
        {
            autoY.Move();
        }
    }
}
