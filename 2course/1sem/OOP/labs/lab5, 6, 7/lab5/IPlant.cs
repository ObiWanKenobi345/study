using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    interface IPlant
    {
        void Pour();
        void Cut();
        void Sell();
        String ToString();
    }
}
