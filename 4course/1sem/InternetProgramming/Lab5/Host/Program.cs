using System;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFSimplex.WCFSimplex)))
            {
                host.Open();
                Console.WriteLine("Host status: OK");
                Console.ReadLine();
            }
        }
    }
}