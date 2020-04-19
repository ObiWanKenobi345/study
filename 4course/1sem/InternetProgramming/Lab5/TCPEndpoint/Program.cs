using System;

namespace TCPEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFSimplex.WCFSimplexClient client = new WCFSimplex.WCFSimplexClient("NetTcpBinding_IWCFSimplex");
            var result = client.Concat("Dmitry", 12.02);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}